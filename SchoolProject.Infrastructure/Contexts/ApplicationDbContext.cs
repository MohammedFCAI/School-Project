using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identities;
using System.Reflection;

namespace SchoolProject.Infrastructure.Context
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


			modelBuilder.Entity<IdentityUserLogin<string>>(b =>
			{
				b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
			});



			modelBuilder.Entity<StudentSubject>()
				.HasKey(t => new { t.StudentId, t.SubjectId });

			modelBuilder.Entity<StudentSubject>()
				.HasOne(pt => pt.Student)
				.WithMany(p => p.StudentSubjects)
				.HasForeignKey(p => p.StudentId);

			modelBuilder.Entity<StudentSubject>()
				.HasOne(pt => pt.Subject)
				.WithMany(p => p.StudentSubjects)
				.HasForeignKey(p => p.SubjectId);

			// --------------

			modelBuilder.Entity<DepartmentSubject>()
				.HasKey(t => new { t.DepartmentId, t.SubjectId });

			modelBuilder.Entity<DepartmentSubject>()
				.HasOne(pt => pt.Department)
				.WithMany(p => p.DepartmentSubjects)
				.HasForeignKey(p => p.DepartmentId);

			modelBuilder.Entity<DepartmentSubject>()
				.HasOne(pt => pt.Subject)
				.WithMany(p => p.DepartmentSubjects)
			.HasForeignKey(p => p.SubjectId);
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
	}
}