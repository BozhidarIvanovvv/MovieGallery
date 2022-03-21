using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieGalleryApp.Infrastructure.Constants
{
    public static class MovieEntityConstants
    {
        public const int TitleMaxLength = 208;
        public const int DescriptionMaxLength = 1000;
        public const int BudgetMaxLength = 50;

        public const double RatingMinValue = 0.00;
        public const double RatingMaxValue = 10.00;
    }
}
