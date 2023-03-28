using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CloudServiceCalc.Models
{
    public class CloudService
    {
        public static string[] InstanceSizeDescriptions
        {
            get
            {
                return new string[] { "Very Small", "Small", "Medium", "Large", "Very Large", "A6", "A7" };
            }
        }

        public static double[] InstanceSizePrices
        {
            get
            {
                return new double[] { 0.02, 0.08, 0.16, 0.32, 0.64, 0.90, 1.80};
            }
        }

        [Required(ErrorMessage ="Required field!")]
        [DisplayName("Instance Size:")]
        public string InstanceSize { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [DisplayName("No Instances:")]
        [Range(2, Int32.MaxValue, ErrorMessage = "Need at least 2 x instances!")]
        public int NoInstances { get; set; }

        public double YearlyCost
        {
            get
            {
                double instancePPH=0;
                for (int i = 0;i< InstanceSizeDescriptions.Length; i++) 
                {
                    if (InstanceSizeDescriptions[i] == this.InstanceSize)
                    {
                        instancePPH = InstanceSizePrices[i];
                        break;
                    }
                }

                double dailyPrice = (instancePPH * NoInstances) *24;

                if (DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    return dailyPrice * 366;
                }
                else
                {
                    return dailyPrice * 365;
                }
            }
        }
    }
}
