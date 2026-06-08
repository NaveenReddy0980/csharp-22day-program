using CareBridge.EFCoreDemo.Models.Generated;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Register EF Core DbContext.
// ASP.NET Core will automatically create and inject it when needed.
builder.Services.AddDbContext<CareBridgeScaffoldContext>();

// Add Swagger support.
// Swagger gives us a testing screen for APIs.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow Vue.js running on another port
// to call this API from the browser.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Enable Swagger.
app.UseSwagger();
app.UseSwaggerUI();

// Enable CORS.
app.UseCors();

// Simple health-check endpoint.
app.MapGet("/", () =>
{
    return "CareBridge API is running";
});

// Return first 20 patients.
// EF Core converts this LINQ query into SQL.
app.MapGet("/api/patients",
    (CareBridgeScaffoldContext db) =>
    {
        return db.Patients

                 // Select only columns we need.
                 .Select(p => new
                 {
                     p.PatientId,
                     p.FullName,
                     p.City
                 })

                 // Return only first 20 rows.
                 .Take(20)

                 // Execute query.
                 .ToList();
    });

app.MapGet("/api/analytics/department",
    (CareBridgeScaffoldContext db,int days=60) =>
    {
        var cutOff = DateTime.Now.AddDays(-days);
        var result = (
        from e in db.Encounters
        join d in db.Departments
        on e.DepartmentId equals d.DepartmentId
        select new
        {
            d.Name,
            e.EncounterType,
            e.AdmitDate
        }

        )
        .Where(y=>y.AdmitDate>cutOff)
        .GroupBy(p => p.Name).Select(g => new
        {
            DepartmentName=g.Key,
            inpatient=g.Count(x=>x.EncounterType=="inpatient"),
            outpatient = g.Count(x => x.EncounterType == "outpatient"),
            ed = g.Count(x => x.EncounterType == "ed"),
            total=g.Count()

        })
        .Where(x=>x.total>0)
        .OrderBy(x=>x.total);
        return result;

        
    });






app.MapGet("/api/patients/search",
    (CareBridgeScaffoldContext db, string? city,bool isActive=false) =>
    {
        
        bool NoisActive = true;
        if (isActive == true)
        {
            NoisActive = false;
        }
        

        if (city != null && (!string.IsNullOrEmpty(city)))
        {
             return db.Patients.Where(p => p.City == city && (NoisActive || p.IsActive == isActive))
            .Select(p => new
            {
                p.PatientId,
                p.FullName,
                p.City,
               
            }).Take(20).ToList();
            
        }
        else
        {
            return db.Patients
            .Where(p => (NoisActive || p.IsActive == isActive))

                    // Select only columns we need.
                    .Select(p => new
                    {
                        p.PatientId,
                        p.FullName,
                        p.City
                    })

                    // Return only first 20 rows.
                    .Take(20)

                    // Execute query.
                    .ToList();

        }
       


    });



app.Run();

