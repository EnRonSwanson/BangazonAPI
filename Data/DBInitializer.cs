using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BangazonAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

// This file written by Mitchell.
// Comments above each section label what is being seeded.

namespace BangazonAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BangazonContext(serviceProvider.GetRequiredService<DbContextOptions<BangazonContext>>()))
            {
                if (context.Customer.Any())
                {
                    return;
                }

                //seeding CUSTOMERS
                var customers = new Customer[]
                {
                    new Customer { 
                        FirstName = "Jelly",
                        LastName = "Otter"
                    },
                    new Customer { 
                        FirstName = "Nigel",
                        LastName = "Thornberry"
                    },
                    new Customer { 
                        FirstName = "Frank",
                        LastName = "Underwood"
                    },
                };

                foreach (Customer i in customers)
                {
                    context.Customer.Add(i);
                }
                context.SaveChanges();

                //seeding COMPUTERS
                var computers = new Computer[]
                {
                    new Computer {},
                    new Computer {},
                    new Computer {}
                };

                foreach (Computer i in computers)
                {
                    context.Computer.Add(i);
                }
                context.SaveChanges();

                //seeding DEPARTMENTS
                var departments = new Department[]
                {
                    new Department { 
                        Name = "Marketing",
                        Budget = 123456
                    },
                    new Department { 
                        Name = "Accounting",
                        Budget = 234567
                    }
                };

                foreach (Department i in departments)
                {
                    context.Department.Add(i);
                }
                context.SaveChanges();

                //seeding EMPLOYEES
                var employees = new Employee[]
                {
                    new Employee { 
                        Name = "Jon Snow"
                    },
                    new Employee { 
                        Name = "Stephen Spielburg"
                    },
                    new Employee { 
                        Name = "Megan Berry"
                    }
                };

                foreach (Employee i in employees)
                {
                    context.Employee.Add(i);
                }
                context.SaveChanges();

                //seeding PAYMENT TYPES
                var paymentTypes = new PaymentType[]
                {
                    new PaymentType { 
                        Type = "Visa",
                        AccountNumber = "12345667890",
                        CustomerId = customers.Single(firstname => firstname.FirstName == "Jelly").CustomerId,
                    },
                    new PaymentType { 
                        Type = "MasterCard",
                        AccountNumber = "2345678901",
                        CustomerId = customers.Single(firstname => firstname.FirstName == "Nigel").CustomerId,
                    },
                    new PaymentType { 
                        Type = "AmericanExpress",
                        AccountNumber = "3456789012",
                        CustomerId = customers.Single(firstname => firstname.FirstName == "Frank").CustomerId,
                    }
                };

                foreach (PaymentType i in paymentTypes)
                {
                    context.PaymentType.Add(i);
                }
                context.SaveChanges();

                //seeding PRODUCT TYPES
                var productTypes = new ProductType[]
                {
                    new ProductType { 
                        Type = "Household"
                    },
                    new ProductType { 
                        Type = "Appliance"
                    },
                    new ProductType { 
                        Type = "Automotive"
                    }
                };

                foreach (ProductType i in productTypes)
                {
                    context.ProductType.Add(i);
                }
                context.SaveChanges();

                //seeding PRODUCTS
                var products = new Product[]
                {
                    new Product { 
                        ProductTypeId = productTypes.Single(s => s.Type == "Household").ProductTypeId,
                        SellerId = customers.Single(s => s.FirstName == "Jelly").CustomerId,
                        Name = "Lamp",
                        Description = "Lights stuff up",
                        Price = 13
                    },
                    new Product { 
                        ProductTypeId = productTypes.Single(s => s.Type == "Appliance").ProductTypeId,
                        SellerId = customers.Single(s => s.FirstName == "Nigel").CustomerId,
                        Name = "Blender",
                        Description = "Mixes stuff",
                        Price = 13
                    },
                    new Product { 
                        ProductTypeId = productTypes.Single(s => s.Type == "Automotive").ProductTypeId,
                        SellerId = customers.Single(s => s.FirstName == "Frank").CustomerId,
                        Name = "Crowbar",
                        Description = "Prys at stuff",
                        Price = 13
                    }
                };

                foreach (Product i in products)
                {
                    context.Product.Add(i);
                }
                context.SaveChanges();

                //seeding TRAINING PROGRAMS
                var trainingPrograms = new TrainingProgram[]
                {
                    new TrainingProgram { 
                        Name = "Doing Your Best",
                        MaxAttendees = 12,
                        StartDate = new DateTime(2018, 8, 28, 2,3,0)
                    },
                    new TrainingProgram { 
                        Name = "Excelling at Excel",
                        MaxAttendees = 21,
                        StartDate = new DateTime(2017, 8, 28, 2,3,0)
                    },
                    new TrainingProgram { 
                        Name = "Bring Your Things",
                        MaxAttendees = 3,
                        StartDate = new DateTime(2016, 7, 28, 2,3,0)
                    },
                    new TrainingProgram { 
                        Name = "Do Life Better",
                        MaxAttendees = 45,
                        StartDate = new DateTime(2015, 7, 28, 2,3,0)
                    }
                };
                
                foreach (TrainingProgram i in trainingPrograms)
                {
                    context.TrainingProgram.Add(i);
                }
                context.SaveChanges();

                //seeding ORDERS, scrambling order of customers so no initial sellerId will equal a buyerId
                var orders = new Order[]
                {
                    new Order { 
                        CustomerId = customers.Single(f => f.FirstName == "Nigel").CustomerId,
                        PaymentTypeId = paymentTypes.Single(t => t.Type == "Visa").PaymentTypeId
                    },
                    new Order {
                        CustomerId = customers.Single(f => f.FirstName == "Frank").CustomerId,
                        PaymentTypeId = paymentTypes.Single(t => t.Type == "MasterCard").PaymentTypeId
                    },
                    new Order { 
                        CustomerId = customers.Single(f => f.FirstName == "Jelly").CustomerId,
                        PaymentTypeId = paymentTypes.Single(t => t.Type == "AmericanExpress").PaymentTypeId
                    }
                };

                foreach (Order i in orders)
                {
                    context.Order.Add(i);
                }
                context.SaveChanges();

                //seeding ORDER-PRODUCTS, matching up with the initialized orders and products by id
                var orderProducts = new OrderProduct[]
                {
                    new OrderProduct {
                        OrderId = orders.Single(o => o.OrderId == 1).OrderId,
                        ProductId = products.Single(o => o.ProductId == 1).ProductId
                    },
                    new OrderProduct {
                        OrderId = orders.Single(o => o.OrderId == 2).OrderId,
                        ProductId = products.Single(o => o.ProductId == 2).ProductId
                    },
                    new OrderProduct {
                        OrderId = orders.Single(o => o.OrderId == 3).OrderId,
                        ProductId = products.Single(o => o.ProductId == 3).ProductId
                    }
                };
                   
                foreach (OrderProduct i in orderProducts)
                {
                    context.OrderProduct.Add(i);
                }
                context.SaveChanges();

                //seeding COMPUTER-EMPLOYEES
                var computerEmployees = new ComputerEmployee[]
                {
                    new ComputerEmployee {
                        EmployeeId = employees.Single(e => e.Name == "Jon Snow").EmployeeId,
                        ComputerId = computers.Single(c => c.ComputerId == 1).ComputerId,
                        InDate = DateTime.Now
                    },
                    new ComputerEmployee {
                        EmployeeId = employees.Single(e => e.Name == "Stephen Spielburg").EmployeeId,
                        ComputerId = computers.Single(c => c.ComputerId == 2).ComputerId,
                        InDate = DateTime.Now
                    },
                    new ComputerEmployee {
                        EmployeeId = employees.Single(e => e.Name == "Megan Berry").EmployeeId,
                        ComputerId = computers.Single(c => c.ComputerId == 3).ComputerId,
                        InDate = DateTime.Now
                    }
                };
                   
                foreach (ComputerEmployee i in computerEmployees)
                {
                    context.ComputerEmployee.Add(i);
                }
                context.SaveChanges();

            }
       }
    }
}