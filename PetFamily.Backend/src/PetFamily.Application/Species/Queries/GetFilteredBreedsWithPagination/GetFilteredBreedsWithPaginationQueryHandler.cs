﻿using PetFamily.Application.Abstractions;
using PetFamily.Application.Database;
using PetFamily.Application.Dtos;
using PetFamily.Application.Extensions;
using PetFamily.Application.Models;

namespace PetFamily.Application.Species.Queries.GetFilteredBreedsWithPagination
{
    public class GetFilteredBreedsWithPaginationQueryHandler
        : IQueryHandler<PagedList<BreedDto>, GetFilteredBreedsWithPaginationQuery>
    {
        private readonly IReadDbContext _readDbContext;

        public GetFilteredBreedsWithPaginationQueryHandler(
            IReadDbContext readDbContext)
        {
            _readDbContext = readDbContext;
        }

        public async Task<PagedList<BreedDto>> Handle(GetFilteredBreedsWithPaginationQuery query, CancellationToken cancelationToken = default)
        {
            var breeds = _readDbContext.Breeds.Where(b => b.SpeciesId == query.SpeciesId);

            breeds = breeds.WhereIf(!string.IsNullOrEmpty(query.Title),
                            b => b.Title.ToLower().Contains(query.Title!.ToLower()));

            var result = await breeds.ToPagedList(query.Page, query.PageSize, cancelationToken);
            return result;
        }
    }

}
