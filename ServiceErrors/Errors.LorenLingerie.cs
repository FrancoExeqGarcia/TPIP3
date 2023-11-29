using ErrorOr;

namespace Loren_TPI_Prog3.ServiceErrors
{
    public static class Errors
    {
        public static class Product
        {
            public static Error InvalidName => Error.Validation(
                code: "Product.InvalidName",
                description: $"The name must be between {Data.Entities.Products.Product.MinNameLength} and {Data.Entities.Products.Product.MaxNameLength} characters long."
            );
            public static Error InvalidDescription => Error.Validation(
           code: "Product.InvalidName",
           description: $"The name must be between {Data.Entities.Products.Product.MinDescriptionLength} and {Data.Entities.Products.Product.MaxDescriptionLength} characters long."
            );
            public static Error NotFound => Error.NotFound(
                code: "Product.NotFound",
                description: "The product was not found."
            );
            public static Error AlreadyDeleted => Error.Conflict(
                code: "Product.AlreadyDeleted",
                description: "The product was already deleted."
            );
        }
        public static class SaleOrder
        {
            public static Error NotFound => Error.NotFound(
                code: "SaleOrder.NotFound",
                description: "The sale order was not found."
            );
            public static Error AlreadyCompleted => Error.Conflict(
                code: "SaleOrder.AlreadyCompleted",
                description: "The sale order was already completed."
            );
            public static Error AlreadyDeleted => Error.Conflict(
                code: "SaleOrder.AlreadyDeleted",
                description: "The sale order was already deleted."
            );
        }
    }
}
