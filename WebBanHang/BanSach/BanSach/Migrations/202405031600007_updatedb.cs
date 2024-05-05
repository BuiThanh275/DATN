namespace BanDongHo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_ProductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Alias = c.String(nullable: false, maxLength: 150),
                        Icon = c.String(maxLength: 250),
                        CreateBy = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.tb_Product", "ProductTypeId", c => c.Int());
            CreateIndex("dbo.tb_Product", "ProductTypeId");
            AddForeignKey("dbo.tb_Product", "ProductTypeId", "dbo.tb_ProductType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Product", "ProductTypeId", "dbo.tb_ProductType");
            DropIndex("dbo.tb_Product", new[] { "ProductTypeId" });
            DropColumn("dbo.tb_Product", "ProductTypeId");
            DropTable("dbo.tb_ProductType");
        }
    }
}
