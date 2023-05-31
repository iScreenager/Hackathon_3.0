using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApi.Models
{
    [Table("HotelTbl")]
    public class MenuClass
    {
        [Key]
        public int itemId { get; set; }
        public string itemName { get; set; } = string.Empty;
        public int itemPrice { get; set; }
        public string itemDescription { get; set; } = string.Empty;
        public string itemImage { get; set; } = string.Empty;


    }
    public class HotellDbContext : DbContext
    {
        public DbSet<MenuClass> MenuData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conString = @"Data Source=W-674PY03-1;Initial Catalog=vaishnavi;Persist Security Info=True;User ID=sa;Password=Password@12345 Integrated Security = True; TrustServerCertificate=True";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(conString);
        }
    }



    public interface IHotelComponent
    {
        List<MenuClass> GetMenu();

        void AddItems(MenuClass menu);
        void UpdateItems(MenuClass menu);
        void RemoveItems(int itemId);


    }

    public class HotelComponent : IHotelComponent
    {
        public void AddItems(MenuClass menu)
        {
            var context = new HotellDbContext();
            context.MenuData.Add(menu);
            context.SaveChanges();
        }

        public List<MenuClass> GetMenu()
        {
            var context = new HotellDbContext();
            return context.MenuData.ToList();

        }

        public void RemoveItems(int itemId)
        {
            var context = new HotellDbContext();
            var rec = context.MenuData.FirstOrDefault(e => e.itemId == itemId);

            if (rec != null)
            {
                context.MenuData.Remove(rec);
                context.SaveChanges();
            }
            else
            {

                throw new Exception("Items not found");
            }
        }

        public void UpdateItems(MenuClass menu)
        {
            var context = new HotellDbContext();
            var rec = context.MenuData.FirstOrDefault(e => e.itemId == menu.itemId);
            if (rec != null)
            {
                rec.itemName = menu.itemName;
                rec.itemPrice = menu.itemPrice;
                rec.itemDescription = menu.itemDescription;
                rec.itemImage = menu.itemImage;
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Items not found");
            }
        }
    }

}
