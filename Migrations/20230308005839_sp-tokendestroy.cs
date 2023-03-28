using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace danj_backend.Migrations
{
    /// <inheritdoc />
    public partial class sptokendestroy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"ALTER PROCEDURE Base_tokenization_destroytoken_procedure(
                        @referenceId INTEGER,
                        @isValid CHAR(1),
                        @StatementType NVARCHAR(20) = '')

                        AS
	                        BEGIN
	                        IF @StatementType = 'auth-token-destroy'
		                        BEGIN
			                        UPDATE tokenization
			                        SET isValid=@isValid
			                        WHERE userId=@referenceId
                                    UPDATE authentication_history
			                        SET isValid=@isValid
			                        WHERE userId=@referenceId
		                        END
	                        END";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userType",
                table: "users");
        }
    }
}
