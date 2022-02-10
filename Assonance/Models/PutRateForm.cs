using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assonance.Models
{
    public class PutRateForm
    {
        public float Rating { get; set; }

        public PutRateForm(float rating)
        {
            Rating = rating;
        }

        public PutRateForm()
        {
        }
    }
}
