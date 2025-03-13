using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhoneNumberSize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(9)",
                oldMaxLength: 9);

            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 11, 'SP', 'RM de São Paulo/RM de Jundiaí/Região Geográfica Imediata de Bragança Paulista', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 12, 'SP', 'Região Metropolitana do Vale do Paraíba e Litoral Norte', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 13, 'SP', 'Região Metropolitana da Baixada Santista/Vale do Ribeira', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 14, 'SP', 'Avaré/Bauru/Botucatu/Jaú/Lins/Marília/Ourinhos', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 15, 'SP', 'Itapetininga/Itapeva/Sorocaba/Tatuí', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 16, 'SP', 'Araraquara/Franca/Jaboticabal/Ribeirão Preto/São Carlos/Sertãozinho', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 17, 'SP', 'Barretos/Catanduva/Fernandópolis/Jales/São José do Rio Preto/Votuporanga', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 18, 'SP', 'Andradina/Araçatuba/Assis/Birigui/Dracena/Presidente Prudente', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 19, 'SP', 'Americana/Campinas/Limeira/Piracicaba/Rio Claro/São João da Boa Vista', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 21, 'RJ', 'Rio de Janeiro e Região Metropolitana/Teresópolis', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 22, 'RJ', 'Cabo Frio/Campos dos Goytacazes/Itaperuna/Macaé/Nova Friburgo', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 24, 'RJ', 'Angra dos Reis/Petrópolis/Volta Redonda/Piraí', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 27, 'ES', 'Vitória e Região Metropolitana/Colatina/Linhares/Santa Maria de Jetibá', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 28, 'ES', 'Cachoeiro de Itapemirim/Castelo/Itapemirim/Marataízes', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 31, 'MG', 'Belo Horizonte e Região Metropolitana/Conselheiro Lafaiete/Ipatinga/Viçosa', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 32, 'MG', 'Barbacena/Juiz de Fora/Muriaé/São João del-Rei/Ubá', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 33, 'MG', 'Almenara/Caratinga/Governador Valadares/Manhuaçu/Teófilo Otoni', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 34, 'MG', 'Araguari/Araxá/Patos de Minas/Uberlândia/Uberaba', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 35, 'MG', 'Alfenas/Guaxupé/Lavras/Poços de Caldas/Pouso Alegre/Varginha', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 37, 'MG', 'Bom Despacho/Divinópolis/Formiga/Itaúna/Pará de Minas', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 38, 'MG', 'Curvelo/Diamantina/Montes Claros/Pirapora/Unaí', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 41, 'PR', 'Curitiba e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 42, 'PR', 'Ponta Grossa/Guarapuava', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 43, 'PR', 'Apucarana/Londrina', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 44, 'PR', 'Maringá/Campo Mourão/Umuarama', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 45, 'PR', 'Cascavel/Foz do Iguaçu', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 46, 'PR', 'Francisco Beltrão/Pato Branco', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 47, 'SC', 'Balneário Camboriú/Blumenau/Itajaí/Joinville', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 48, 'SC', 'Florianópolis e Região Metropolitana/Criciúma', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 49, 'SC', 'Caçador/Chapecó/Concórdia/Lages', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 51, 'RS', 'Porto Alegre e Região Metropolitana/Santa Cruz do Sul/Litoral Norte', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 53, 'RS', 'Pelotas/Rio Grande', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 54, 'RS', 'Caxias do Sul/Passo Fundo', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 55, 'RS', 'Santa Maria/Santana do Livramento/Santo Ângelo/Uruguaiana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 61, 'DF', 'Abrangência em todo o DF e alguns municípios da Região Integrada de Desenvolvimento do DF e Entorno', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 62, 'GO', 'Goiânia e Região Metropolitana/Anápolis/Niquelândia/Porangatu', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 63, 'TO', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 64, 'GO', 'Caldas Novas/Catalão/Itumbiara/Rio Verde', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 65, 'MT', 'Cuiabá e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 66, 'MT', 'Rondonópolis/Sinop', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 67, 'MS', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 68, 'AC', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 69, 'RO', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 71, 'BA', 'Salvador e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 73, 'BA', 'Eunápolis/Ilhéus/Porto Seguro/Teixeira de Freitas', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 74, 'BA', 'Irecê/Jacobina/Juazeiro/Xique-Xique', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 75, 'BA', 'Alagoinhas/Feira de Santana/Paulo Afonso/Valença', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 77, 'BA', 'Barreiras/Bom Jesus da Lapa/Guanambi/Vitória da Conquista', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 79, 'SE', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 81, 'PE', 'Recife e Região Metropolitana/Caruaru', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 82, 'AL', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 83, 'PB', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 84, 'RN', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 85, 'CE', 'Fortaleza e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 86, 'PI', 'Teresina e alguns municípios da Região Integrada de Desenvolvimento da Grande Teresina/Parnaíba', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 87, 'PE', 'Garanhuns/Petrolina/Salgueiro/Serra Talhada', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 88, 'CE', 'Juazeiro do Norte/Sobral', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 89, 'PI', 'Picos/Floriano', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 91, 'PA', 'Belém e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 92, 'AM', 'Manaus e Região Metropolitana/Parintins', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 93, 'PA', 'Santarém/Altamira', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 94, 'PA', 'Marabá', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 95, 'RR', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 96, 'AP', 'Abrangência em todo o estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 97, 'AM', 'Abrangência no interior do estado', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 98, 'MA', 'São Luís e Região Metropolitana', LOCALTIMESTAMP, null)");
            migrationBuilder.Sql("INSERT INTO \"Regional\"(\"Id\", \"Ddd\", \"Estado\", \"Nome\", \"CriadoEm\", \"AlteradoEm\") VALUES(gen_random_uuid(), 99, 'MA', 'Caxias/Codó/Imperatriz', LOCALTIMESTAMP, null)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Contato",
                type: "character varying(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }
    }
}
