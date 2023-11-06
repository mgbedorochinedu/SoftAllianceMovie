using SoftAllianceMovie.Data;

namespace SoftAllianceMovie.Services.GenreService
{
    public class GenreService
    {
        private readonly DataContext _context;
        public GenreService(DataContext context)
        {
            _context = context;
        }


        public async Task<BaseResponse> AddProgramDetail(ProgramDetailDto programDetailDto)
        {
            try
            {

                ProgramDetail programDetail = new ProgramDetail()
                {
                    Title = programDetailDto.Title,
                    ProgramSummary = programDetailDto.ProgramSummary,
                    ProgramDescription = programDetailDto.ProgramDescription,
                    ProgramBenefit = programDetailDto.ProgramBenefit,
                    ApplicationCriteria = programDetailDto.ApplicationCriteria,
                    ProgramType = programDetailDto.ProgramType,
                    ProgramStartDate = programDetailDto.ProgramStartDate,
                    ApplicationOpenDate = programDetailDto.ApplicationOpenDate,
                    ApplicationCloseDate = programDetailDto.ApplicationCloseDate,
                    Duration = programDetailDto.Duration,
                    ProgramLocation = programDetailDto.ProgramLocation,
                    MinQualification = programDetailDto.MinQualification,
                    MaxAppNumber = programDetailDto.MaxAppNumber,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.AddAsync(programDetail);
                var isSaved = await _context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, null, "Successfully saved Program Details");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to save Program Details");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }
    }
}
