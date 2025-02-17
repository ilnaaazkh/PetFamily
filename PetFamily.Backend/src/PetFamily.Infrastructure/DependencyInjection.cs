﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using PetFamily.Application.Messaging;
using PetFamily.Application.Providers;
using PetFamily.Application.Species;
using PetFamily.Application.Volunteers;
using PetFamily.Infrastructure.BackgroundServices;
using PetFamily.Infrastructure.MessageQueues;
using PetFamily.Infrastructure.Options;
using PetFamily.Infrastructure.Providers;
using PetFamily.Infrastructure.Repositories;
using PetFamily.Infrastructure.Services;

namespace PetFamily.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
            services.AddScoped<DeleteExpiredVolunteersService>();
            services.AddScoped<IVolunteersRepository, VolunteersRepository>();
            services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            services.AddSingleton<IMessageQueue<IEnumerable<FileMetadata>>, InMemoryMessageQueue<IEnumerable<FileMetadata>>>();

            services.AddHostedService<DeleteExpiredVolunteersBackgroundService>();
            services.AddHostedService<FilesCleanerBackgroundService>();

            services.AddMinio(configuration);

            return services;
        }

        private static IServiceCollection AddMinio(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MinioOptions>(configuration.GetSection(MinioOptions.MINIO));

            services.AddMinio(options =>
            {
                var minioOptions = configuration.GetSection(MinioOptions.MINIO).Get<MinioOptions>()
                    ?? throw new ApplicationException("Missing minio configuration");

                options.WithEndpoint(minioOptions.Endpoint);
                options.WithCredentials(minioOptions.AccessKey, minioOptions.SecretKey);
                options.WithSSL(minioOptions.WithSSL);
            });

            services.AddScoped<IFilesProvider, MinioProvider>();

            return services;
        }
    }
}
