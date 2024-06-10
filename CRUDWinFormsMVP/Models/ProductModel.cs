using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP.Models
{
    public class ProductModel
    {
        private int id;
        private string title;
        private int price;
        private int ammount;
        private float grade;

        [DisplayName("Product ID")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("Title")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Username length must be between 1 and 100 characters")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        [DisplayName("Price")]
        [Required(ErrorMessage = "Username is required")]
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        [DisplayName("Ammount")]
        [Required(ErrorMessage = "Username is required")]
        public int Ammount
        {
            get { return ammount; }
            set { ammount = value; }
        }

        [DisplayName("Grade")]
        public float Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
