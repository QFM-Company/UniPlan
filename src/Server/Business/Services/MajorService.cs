using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Business.Services
{
    public class MajorService : IMajorService
    {
        private IMajorRepository _majorRepository;
        private Major? _major;

        public MajorService(IMajorRepository majorRepository)
        {
            _majorRepository = majorRepository;
            _major = null;
        }

        private Major _RequestToMajor(MajorRequest request , int majorID = -1)
        {
            return new Major(majorID, request.MajorName);
        }

        private MajorResponse? _MajorToResponse(Major Major)
        {
            return new MajorResponse(Major.MajorID, Major.MajorName);
        }

        public async Task<bool> DeleteMajorAsync(int MajorID)
        {
            return await _majorRepository.DeleteMajorAsync(MajorID);
        }

        public async Task<MajorResponse?> AddMajorAsync(MajorRequest request)
        {
            MajorResponse? majorResponse = null;

            if (request != null)
            {
                _major = _RequestToMajor(request);
                _major.MajorID = await _majorRepository.AddMajorAsync(_major);
                majorResponse = _MajorToResponse(_major);
            }

            return majorResponse;
        }

        public async Task<MajorResponse?> UpdateMajorAsync(MajorRequest request, int majorID)
        {
            MajorResponse? majorResponse = null;

            if (request != null)
            {
                _major = _RequestToMajor(request, majorID);
                await _majorRepository.UpdateMajorAsync(_major);
                majorResponse = _MajorToResponse(_major);
            }

            return majorResponse;
        }

        public async Task<IEnumerable<MajorResponse>?> GetPagedMajorsAsync(int pageNumber = 1, int pageSize = 10)
        {
            IEnumerable<Major>? majors = await _majorRepository.GetPagedMajorsAsync(pageNumber, pageSize);
            var responses = majors?.ToList();
            return responses?.Select(h => _MajorToResponse(h)).OfType<MajorResponse>();
        }

        public async Task<MajorResponse?> GetMajorByIDAsync(int MajorID)
        {
            _major = await _majorRepository.GetMajorByIDAsync(MajorID);
            return _major != null ? _MajorToResponse(_major) : null;
        }
    }
}
