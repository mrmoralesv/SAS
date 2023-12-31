﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Viaticos");

            migrationBuilder.EnsureSchema(
                name: "Cobranza");

            migrationBuilder.CreateTable(
                name: "CatalogoProducto",
                schema: "Viaticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la clase de los productos")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Division = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Nombre de la Division"),
                    Grupo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "grupo de la Division"),
                    Clase = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "Clase de la Division")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Primary key for DatabaseLog records.")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTime = table.Column<DateTime>(type: "datetime", nullable: false, comment: "The date and time the DDL change occurred."),
                    DatabaseUser = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "The user who implemented the DDL change."),
                    Event = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "The type of DDL statement that was executed."),
                    Schema = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "The schema to which the changed object belongs."),
                    Object = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true, comment: "The object that was changed by the DDL statment."),
                    TSQL = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "The exact Transact-SQL statement that was executed."),
                    XmlEvent = table.Column<string>(type: "xml", nullable: true, comment: "The raw XML data generated by database trigger.")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseLog", x => x.Id);
                },
                comment: "Audit table tracking all DDL changes made to the AdventureWorks database. Data is captured by the database trigger ddlDatabaseTriggerLog.");

            migrationBuilder.CreateTable(
                name: "ProductoValido",
                schema: "Viaticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto"),
                    CatalogoProductoID = table.Column<int>(type: "int", nullable: false, comment: "Identificador para clasificacion del producto"),
                    NombreProducto = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true, comment: "Descripcion del producto"),
                    Estatus = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))", comment: "0= Producto no valido para SINCI 1=Producto valido para SINCI"),
                    FechaInsert = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())", comment: "Fecha en que se inserto el producto")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoValido", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReporteGastos",
                schema: "Viaticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador para los cada uno de los reportes de gastos")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VIATICO = table.Column<int>(type: "int", nullable: false, comment: "Idetificador para cada uno de los viaticos"),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha inicio del reporte de gastos"),
                    FechaFin = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha fin del reporte de gastos"),
                    Estatus = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))", comment: "0=No validado 1=Validado"),
                    FechaInsert = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())", comment: "Fecha en que se genero el reporte de gastos")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteGastos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saldo",
                schema: "Cobranza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador para cada uno de los aumentos o disminuciones de saldo")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PERSONAL = table.Column<int>(type: "int", nullable: false, comment: "Identificador personal del trabajador"),
                    SaldoAD = table.Column<decimal>(type: "money", nullable: true, comment: "Aumentos y disminuciones de saldo"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saldo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                schema: "Viaticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la factura")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReporteGastosID = table.Column<int>(type: "int", nullable: false, comment: "Identificador del reporte de gastos al que pertenece la factura"),
                    Estatus = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))", comment: "0=Factura cancelada, 1=Factura autorizada"),
                    RFCEmisor = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true, comment: "RFC del emisor de la factura"),
                    RFCReceptor = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true, comment: "RFC del receptor de la factura"),
                    Total = table.Column<decimal>(type: "money", nullable: false, comment: "Monto total de la factura"),
                    UUID = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true, comment: "UUID de la factura"),
                    SelloSAT = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true, comment: "Sello digital de emisor"),
                    FechaTimbrado = table.Column<DateTime>(type: "datetime", nullable: false, comment: "Fecha del timbrado de la factura"),
                    FechaInsert = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())", comment: "Fecha de la insercion de la factura"),
                    XmlFactura = table.Column<string>(type: "xml", nullable: true, comment: "XML de la factura")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_ReporteGastos_ReporteGastosID",
                        column: x => x.ReporteGastosID,
                        principalSchema: "Viaticos",
                        principalTable: "ReporteGastos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaldoDetalle",
                schema: "Cobranza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaldoID = table.Column<int>(type: "int", nullable: false, comment: "Identificador del aumento o disminucion de saldo"),
                    SaldoAD = table.Column<decimal>(type: "money", nullable: true, comment: "Aumentos y disminuciones de saldo"),
                    Descripcion = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true, comment: "Descripcion del aumento o disminucion de saldo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaldoDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobranza_Saldo_SaldoID",
                        column: x => x.SaldoID,
                        principalSchema: "Cobranza",
                        principalTable: "Saldo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                schema: "Viaticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaID = table.Column<int>(type: "int", nullable: false, comment: "Identificador de la factura"),
                    ProductoValidoID = table.Column<int>(type: "int", nullable: false, comment: "Identificador del producto que esta validado para poder facturar,Clave Servicio o Producto"),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad de servicios o productos"),
                    Descripcion = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, comment: "Descripcion de servicio o producto"),
                    ValorUnitario = table.Column<decimal>(type: "money", nullable: false, comment: "Valor unitario de servicio o producto"),
                    Impuestos = table.Column<decimal>(type: "money", nullable: false, comment: "Impuestos"),
                    Notas = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true, comment: "Notas para el administrador de los viaticos")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Viaticos_Factura_FacturaID",
                        column: x => x.FacturaID,
                        principalSchema: "Viaticos",
                        principalTable: "Factura",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "index_UUID",
                schema: "Viaticos",
                table: "Factura",
                column: "UUID",
                unique: true,
                filter: "[UUID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ReporteGastosID",
                schema: "Viaticos",
                table: "Factura",
                column: "ReporteGastosID");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_FacturaID",
                schema: "Viaticos",
                table: "FacturaDetalle",
                column: "FacturaID");

            migrationBuilder.CreateIndex(
                name: "IX_SaldoDetalle_SaldoID",
                schema: "Cobranza",
                table: "SaldoDetalle",
                column: "SaldoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogoProducto",
                schema: "Viaticos");

            migrationBuilder.DropTable(
                name: "DatabaseLog");

            migrationBuilder.DropTable(
                name: "FacturaDetalle",
                schema: "Viaticos");

            migrationBuilder.DropTable(
                name: "ProductoValido",
                schema: "Viaticos");

            migrationBuilder.DropTable(
                name: "SaldoDetalle",
                schema: "Cobranza");

            migrationBuilder.DropTable(
                name: "Factura",
                schema: "Viaticos");

            migrationBuilder.DropTable(
                name: "Saldo",
                schema: "Cobranza");

            migrationBuilder.DropTable(
                name: "ReporteGastos",
                schema: "Viaticos");
        }
    }
}
