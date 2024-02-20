using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class FixForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedido_PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Produto_ProdutoId",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "ItensPedido");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ItensPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdPedido",
                table: "ItensPedido",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_IdProduto",
                table: "ItensPedido",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedido_IdPedido",
                table: "ItensPedido",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Produto_IdProduto",
                table: "ItensPedido",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedido_IdPedido",
                table: "ItensPedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Produto_IdProduto",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_IdPedido",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_IdProduto",
                table: "ItensPedido");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "ItensPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ItensPedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedido_PedidoId",
                table: "ItensPedido",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Produto_ProdutoId",
                table: "ItensPedido",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
