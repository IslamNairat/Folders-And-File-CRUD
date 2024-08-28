using Microsoft.EntityFrameworkCore;
using XelePro.Context;
using XelePro.Repository;
using XelePro.Services;
using XelePro.Shared;
using XelePro.Shared.Interface;
using XelePro.UOWork;

namespace XelePro
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddScoped<IFoldersService, FoldersService>();
            builder.Services.AddScoped<IFilesService, FilesService>();
            builder.Services.AddScoped<IFolderRepositry, FolderRepositry>();
            builder.Services.AddScoped<IFileRepositry, FileRepositry>();
            builder.Services.AddAutoMapper(typeof(XelePro.Mapping.MappingProfile));
            builder.Services.AddScoped<IUOW<ApplicationDbContext>, UOW<ApplicationDbContext>>();
            builder.Services.AddScoped<IXeleProUnitOfWork, XeleProUnitOfWork>();

            builder.Services.AddCors();

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
