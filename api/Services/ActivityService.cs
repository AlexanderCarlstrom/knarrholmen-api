using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Contexts;
using api.Contracts.Requests;
using api.Contracts.Responses;
using api.DTOs;
using api.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public interface IActivityService
    {
        Task<ApiResponse> Create(ActivityRequest model);
        Task<ActivityResponse> GetOne(string activityId);
        ActivityResponse Search(ActivitySearchRequest model);
    }

    public class ActivityService : IActivityService
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly IMapper _mapper;

        public ActivityService(BookingDbContext bookingDbContext, IMapper mapper)
        {
            _bookingDbContext = bookingDbContext;
            _mapper = mapper;
        }

        public async Task<ApiResponse> Create(ActivityRequest model)
        {
            var activity = new Activity(model.Name.ToLower(), model.Description, model.Location, model.Open, model.Close);

            try
            {
                await _bookingDbContext.Activities.AddAsync(activity);
                await _bookingDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new ApiResponse(400, "Could not create activity");
            }

            return new ApiResponse(201, "Activity Created");
        }

        public async Task<ActivityResponse> GetOne(string activityId)
        {
            var activity = await _bookingDbContext.Activities.FindAsync(activityId);
            if (activity == null)
            {
                return new ActivityResponse(400, "Could not find activity");
            }

            var activityDto = _mapper.Map<ActivityDto>(activity);
            return new ActivityResponse(200, activityDto);
        }

        public ActivityResponse Search(ActivitySearchRequest model)
        {
            List<ActivitiesDto> result;
            if (string.IsNullOrEmpty(model.Search))
            {
                result = _bookingDbContext.Activities.OrderBy(a => a.Name).Skip(model.Start).Take(model.Limit)
                    .Select(a => _mapper.Map<ActivitiesDto>(a)).ToList();
                return new ActivityResponse(200, result);
            }
            result = _bookingDbContext.Activities.Where(a => EF.Functions.Like(a.Name, "%" + model.Search.ToLower() + "%"))
                .OrderBy(a => a.Name)
                .Skip(model.Start).Take(model.Limit)
                .Select(a => _mapper.Map<ActivitiesDto>(a)).ToList();
            return new ActivityResponse(200, result);
        }
    }
}