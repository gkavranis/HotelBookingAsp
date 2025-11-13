//namespace HotelBooking.Infrastructure;

//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//internal class HotelBookingDbContextFactory : IDesignTimeDbContextFactory<HotelBookingDbContext>
//{
//    public HotelBookingDbContext CreateDbContext(string[] args)
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<HotelBookingDbContext>();
//        optionsBuilder.UseSqlServer("Server=localhost\\\\MSSQLSERVER2022,1433;Database=HotelBooking;User ID=sa;Password=attemptStrongP@ssw0rd;TrustServerCertificate=True;");

//        return new HotelBookingDbContext(optionsBuilder.Options);
//    }
//}