// <auto-generated />
using FirstVariant.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstVariant.Migrations
{
    [DbContext(typeof(GoodsAndOrdersDbContext))]
    [Migration("20220228154849_GoodAndOrder")]
    partial class GoodAndOrder
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirstVariant.Models.CustomersModel", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerName = "Александр"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerName = "Татьяна"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerName = "Иван"
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerName = "Владислав"
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerName = "Алексей"
                        },
                        new
                        {
                            CustomerId = 6,
                            CustomerName = "Анастасия"
                        });
                });

            modelBuilder.Entity("FirstVariant.Models.GoodsModel", b =>
                {
                    b.Property<int>("GoodItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GoodItemName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GoodItemId");

                    b.ToTable("Goods");

                    b.HasData(
                        new
                        {
                            GoodItemId = 1,
                            GoodItemName = "Шкаф",
                            Price = 13050m
                        },
                        new
                        {
                            GoodItemId = 2,
                            GoodItemName = "Стул",
                            Price = 3050m
                        },
                        new
                        {
                            GoodItemId = 3,
                            GoodItemName = "Диван",
                            Price = 23410m
                        },
                        new
                        {
                            GoodItemId = 4,
                            GoodItemName = "Компьютерный стол",
                            Price = 7250m
                        },
                        new
                        {
                            GoodItemId = 5,
                            GoodItemName = "Карниз",
                            Price = 3050m
                        },
                        new
                        {
                            GoodItemId = 6,
                            GoodItemName = "Бетон",
                            Price = 350m
                        });
                });

            modelBuilder.Entity("FirstVariant.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GoodItemId")
                        .HasColumnType("int");

                    b.Property<long>("OrderMasterId")
                        .HasColumnType("bigint");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("GoodItemId");

                    b.HasIndex("OrderMasterId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("FirstVariant.Models.OrderMaster", b =>
                {
                    b.Property<long>("OrderMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("OrderNumberId")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderMasterId");

                    b.HasIndex("CustomerId");

                    b.ToTable("OrderMaster");
                });

            modelBuilder.Entity("FirstVariant.Models.OrderDetails", b =>
                {
                    b.HasOne("FirstVariant.Models.GoodsModel", "GoodItem")
                        .WithMany()
                        .HasForeignKey("GoodItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstVariant.Models.OrderMaster", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoodItem");
                });

            modelBuilder.Entity("FirstVariant.Models.OrderMaster", b =>
                {
                    b.HasOne("FirstVariant.Models.CustomersModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("FirstVariant.Models.OrderMaster", b =>
                {
                    b.Navigation("OrderDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
