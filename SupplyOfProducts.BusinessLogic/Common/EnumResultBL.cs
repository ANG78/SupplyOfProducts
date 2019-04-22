using SupplyOfProducts.Interfaces.BusinessLogic;
using SupplyOfProducts.Interfaces.Common;
using SupplyOfProducts.Interfaces.ICommon;

namespace SupplyOfProducts.BusinessLogic.Common
{
    public enum EnumResultBL
    {
        [Description("OK")]
        OK = 0,

        [Description("OK and finish the Execution: {0}")]
        OK_AND_FINISH_STEPS = 1,

        [Description("Valid Product Code is requiered")]
        ERROR_PRODUCT_REQUIRED,

        [Description("Valid Period Date is requiered")]
        ERROR_PERIODDATE_NOT_POSSIBLE_TO_BE_CALCULATED,

        [Description("Number of years by Period is zero")]
        ERROR_NUM_YEARS_BY_PERIOD_IS_ZERO,

        [Description("Period Date is not possible to be calculated {0} < {1}")]
        ERROR_PERIOD_DATE_NOT_POSSIBLE_TO_BE_CALCULATED,

        [Description("Valid User is requiered: {0}")]
        ERROR_USER_REQUIRED,

        [Description("Valid Workplace is required")]
        ERROR_WORKPLACE_REQUIRED,

        [Description("Unexpected Error When Save Product Supply: {0}")]
        ERROR_EXCEPTION_PERSISTANCE_PRODUCT_SUPPLY,

        [Description("Unexpected Exception: {0}")]
        ERROR_UNEXPECTED_EXCEPTION,

        [Description("Not available product with code : {0}")]
        ERROR_NO_PRODUCT_AVAILABE,

        [Description("the implementation of the Step is returning not expected values: {0} ")]
        ERROR_BAD_IMPLEMENTATION,

        [Description("Not Found a relactionship between the Worker {0}  and the Workplace {1} in the date {2} ")]
        ERROR_WORKER_DOES_NOT_WORK_IN_THIS_WORKPLACE_IN_THIS_DATE,

        [Description("Not Found a supply of this product {0} for the worker {1}  in the workplace {2} and date {3} ")]
        ERROR_WORKER_NOT_FOUND_A_SUPPLY_SCHEDULED_OF_THE_PRODUCT_FOR_THE_WORKER_AND_WORKPLACE_IN_THE_DATE,

        [Description("The worker {0}  has reached the limit ({1}) of products of this kind ({2}) for the workplace {3} in this period {4}")]
        ERROR_WORKER_HAS_REACHED_THE_LIMIT_OF_PRODUCTS_OF_THIS_TYPE,

        [Description("The new amount meant to be set for the product {0} and worker {1} and workplace {2} is smaller than the one already supplied upto date {3}")]
        ERROR_THE_NEW_AMOUNT_MEANT_TO_BE_SET_IS_SMALLER_THAN_THE_ONE_ALREADY_SUPPLIED,

        ERROR_VALIDATION,

        ERROR_PRODUCT_IN_STOCK_WAS_ALREADY_BOOKED,

        ERROR_PRODUCT_SUPPLIED_NOT_COMPLETED
    }

   

   

    
}
