using PhotoContest.Data.Models;
using PhotoContest.Services.Models;
using PhotoContest.Services.Models.Create;
using PhotoContest.Services.Models.Update;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoContest.Services.Contracts
{
    public interface IPhotoService
    {
        Task<PhotoDTO> CreateAsync(NewPhotoDTO photoDTO);
        Task<PhotoDTO> CreateApiAsync(NewPhotoDTO photoDTO);
        Task<PhotoDTO> GetAsync(Guid id);
        Task<IEnumerable<PhotoDTO>> GetAllAsync();
        Task<PhotoDTO> UpdateAsync(UpdatePhotoDTO photoDTO, Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<List<PhotoDTO>> GetPhotosForContestAsync(string contestName);
        Task<List<PhotoReviewDTO>> GetAllWithCommentsAndScoreAsync(string contestName);
        Task<List<PhotoReviewDTO>> GetAllWithCommentsAndScoreApiAsync(string contestName);
        Task<Photo> FindPhotoAsync(Guid id);
        Task<List<PhotoDTO>> GetPhotosForUserAsync(); 
        Task<IEnumerable<Photo>> GetAllBaseAsync();
    }
}
