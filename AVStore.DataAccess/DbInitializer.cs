using System.Collections.Generic;
using System.Linq;
using AVStore.Domain.Entities;

namespace AVStore.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            if (!context.DetailTypes.Any())
            {
                context.DetailTypes.AddRange(DetailType.List().ToList());
            }

            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Name = "Super X1 Camera",
                    Description =
                        "The Super X1 camera is the top of the line DSLR camera by Super. With a full frame stabalised sensor you'll be taking the sharpest images with ease!",
                    InStock = true,
                    Price = 9999.99m,
                    ProductDetails = new List<ProductDetail>
                    {
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Color",
                                Value = "Black",
                                Type = DetailType.PrimaryColor
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Color",
                                Value = "Red",
                                Type = DetailType.SecondaryColor
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Brand",
                                Value = "Super",
                                Type = DetailType.Brand
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Dimensions",
                                Value = "120x80x130 mm",
                                Type = DetailType.Dimensions
                            }
                        }
                    }
                });
                context.Products.Add(new Product
                {
                    Name = "Super A1 Camera",
                    Description =
                        "The Super A1 camera is a budget freindly camera for the general consumer, easy to use and light weight",
                    InStock = false,
                    Price = 999.99m,
                    ProductDetails = new List<ProductDetail>
                    {
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Color",
                                Value = "Black",
                                Type = DetailType.PrimaryColor
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Color",
                                Value = "Red",
                                Type = DetailType.SecondaryColor
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Brand",
                                Value = "Super",
                                Type = DetailType.Brand
                            }
                        },
                        new ProductDetail
                        {
                            Detail = new Detail
                            {
                                Key = "Dimensions",
                                Value = "100x60x50 mm",
                                Type = DetailType.Dimensions
                            }
                        }
                    }
                });
            }
            context.SaveChanges();
        }
    }
}
