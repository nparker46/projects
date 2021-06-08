using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DatabaseManager
{
     public partial class CreateForm : Form
     {

          public CreateForm()
          {
               InitializeComponent();
          }


          private void CreateForm_Load(object sender, EventArgs e)
          {
               comboBox1.SelectedIndex = 0;
          }

          private void button1_Click(object sender, EventArgs e)
          {

               if (comboBox1.SelectedIndex == 0)
               {
                    Variables.login = "Persist Security Info=False;User ID=" + Variables.user + ";Password=" + Variables.pass + ";Initial Catalog=master;Server=" + Variables.server; MessageBox.Show(Variables.server);
                    SqlConnection con = new SqlConnection(Variables.login);
                    con.Open();
                    try
                    {
                         using (con) // creates the database and records
                         {
                              SqlCommand command = con.CreateCommand();
                              command.CommandText = "CREATE DATABASE COLOR_DB";
                              command.ExecuteNonQuery();

                              SqlCommand command2 = con.CreateCommand();
                              command2.CommandText = @"IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')) begin EXEC [COLOR_DB].[dbo].[sp_fulltext_database] @action = 'enable' end ALTER DATABASE [COLOR_DB] SET ANSI_NULL_DEFAULT OFF ALTER DATABASE [COLOR_DB] SET ANSI_NULLS OFF ALTER DATABASE [COLOR_DB] SET ANSI_PADDING OFF ALTER DATABASE [COLOR_DB] SET ANSI_WARNINGS OFF ALTER DATABASE [COLOR_DB] SET ARITHABORT OFF ALTER DATABASE [COLOR_DB] SET AUTO_CLOSE OFF ALTER DATABASE [COLOR_DB] SET AUTO_CREATE_STATISTICS ON ALTER DATABASE [COLOR_DB] SET AUTO_SHRINK OFF ALTER DATABASE [COLOR_DB] SET AUTO_UPDATE_STATISTICS ON ALTER DATABASE [COLOR_DB] SET CURSOR_CLOSE_ON_COMMIT OFF ALTER DATABASE [COLOR_DB] SET CURSOR_DEFAULT GLOBAL ALTER DATABASE [COLOR_DB] SET CONCAT_NULL_YIELDS_NULL OFF ALTER DATABASE [COLOR_DB] SET NUMERIC_ROUNDABORT OFF ALTER DATABASE [COLOR_DB] SET QUOTED_IDENTIFIER OFF ALTER DATABASE [COLOR_DB] SET RECURSIVE_TRIGGERS OFF ALTER DATABASE [COLOR_DB] SET DISABLE_BROKER ALTER DATABASE [COLOR_DB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF ALTER DATABASE [COLOR_DB] SET DATE_CORRELATION_OPTIMIZATION OFF ALTER DATABASE [COLOR_DB] SET TRUSTWORTHY OFF ALTER DATABASE [COLOR_DB] SET ALLOW_SNAPSHOT_ISOLATION OFF ALTER DATABASE [COLOR_DB] SET PARAMETERIZATION SIMPLE ALTER DATABASE [COLOR_DB] SET READ_COMMITTED_SNAPSHOT OFF ALTER DATABASE [COLOR_DB] SET HONOR_BROKER_PRIORITY OFF ALTER DATABASE [COLOR_DB] SET READ_WRITE ALTER DATABASE [COLOR_DB] SET RECOVERY FULL ALTER DATABASE [COLOR_DB] SET MULTI_USER ALTER DATABASE [COLOR_DB] SET PAGE_VERIFY CHECKSUM ALTER DATABASE [COLOR_DB] SET DB_CHAINING OFF EXEC sys.sp_db_vardecimal_storage_format N'COLOR_DB', N'ON' USE [COLOR_DB] /****** Object: Table [dbo].[RGB] Script Date: 12/07/2015 09:54:49 ******/ SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON CREATE TABLE [dbo].[RGB]( [ID] [int] NOT NULL, [Red] [int] NOT NULL, [Green] [int] NOT NULL, [Blue] [int] NOT NULL, CONSTRAINT [PK_RGB] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (1, 239, 222, 205) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (2, 0, 255, 255) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (3, 245, 245, 220) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (4, 0, 0, 0) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (5, 0, 0, 255) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (6, 165, 42, 42) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (7, 0, 255, 255) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (8, 128, 128, 128) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (9, 0, 255, 0) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (10, 255, 255, 240) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (11, 230, 230, 250) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (12, 50, 205, 50) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (13, 128, 0, 0) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (14, 0, 0, 128) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (15, 255, 165, 0) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (16, 128, 0, 128) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (17, 255, 0, 0) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (18, 48, 213, 200) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (19, 255, 255, 255) INSERT [dbo].[RGB] ([ID], [Red], [Green], [Blue]) VALUES (20, 255, 255, 0) /****** Object: Table [dbo].[HSL] Script Date: 12/07/2015 09:54:49 ******/ SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON CREATE TABLE [dbo].[HSL]( [ID] [int] NOT NULL, [Red] [int] NOT NULL, [Green] [int] NOT NULL, [Blue] [int] NOT NULL, CONSTRAINT [PK_HSL] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (1, 55, 87, 52) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (2, 180, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (3, 245, 245, 220) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (4, 60, 56, 91) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (5, 240, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (6, 0, 59, 41) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (7, 180, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (8, 0, 0, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (9, 120, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (10, 60, 100, 97) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (11, 240, 67, 94) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (12, 120, 61, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (13, 0, 100, 25) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (14, 240, 100, 25) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (15, 39, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (16, 300, 100, 25) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (17, 0, 100, 50) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (18, 175, 66, 51) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (19, 0, 0, 100) INSERT [dbo].[HSL] ([ID], [Red], [Green], [Blue]) VALUES (20, 60, 100, 50) /****** Object: Table [dbo].[HEX] Script Date: 12/07/2015 09:54:49 ******/ SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON SET ANSI_PADDING ON CREATE TABLE [dbo].[HEX]( [ID] [int] NOT NULL, [Hex] [char](7) NULL, CONSTRAINT [PK_HEX] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] SET ANSI_PADDING OFF INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (1, N'#EFDEC2') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (2, N'#00FFFF') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (3, N'#F5F5DC') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (4, N'#000000') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (5, N'#0000FF') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (6, N'#F4A460') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (7, N'#00FFFF') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (8, N'#808080') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (9, N'#00FF00') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (10, N'#FFFFF0') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (11, N'#E6E6FA') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (12, N'#32CD32') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (13, N'#800000') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (14, N'#000080') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (15, N'#FFA500') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (16, N'#800080') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (17, N'#FF0000') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (18, N'#30D5C8') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (19, N'#FFFFFF') INSERT [dbo].[HEX] ([ID], [Hex]) VALUES (20, N'#FFFF00') /****** Object: Table [dbo].[COLOR_NAME] Script Date: 12/07/2015 09:54:49 ******/ SET ANSI_NULLS ON SET QUOTED_IDENTIFIER ON SET ANSI_PADDING ON CREATE TABLE [dbo].[COLOR_NAME]( [Name] [varchar](50) NOT NULL, [ID] [int] NOT NULL, CONSTRAINT [PK_COLOR_NAME] PRIMARY KEY CLUSTERED ( [ID] ASC )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY] ) ON [PRIMARY] SET ANSI_PADDING OFF INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Almond', 1) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Aqua', 2) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Beige', 3) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Black', 4) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Blue', 5) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Brown', 6) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Cyan', 7) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Gray', 8) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Green', 9) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Ivory', 10) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Lavender', 11) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Lime Green', 12) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Maroon', 13) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Navy Blue', 14) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Orange', 15) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Purple', 16) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Red', 17) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Turquoise', 18) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'White', 19) INSERT [dbo].[COLOR_NAME] ([Name], [ID]) VALUES (N'Yellow', 20)";
                              command2.ExecuteNonQuery();
                         }
                         Variables.login = "Persist Security Info=False;User ID=" + Variables.user + ";Password=" + Variables.pass + ";Initial Catalog=COLOR_DB;Server=" + Variables.server;
                         MessageBox.Show("The tables were successfully created.");
                         this.Close();
                    }
                         catch
                         {
                              MessageBox.Show("An unexpected error occurred. Please contact the system administrator. ", "Message Box", MessageBoxButtons.OK, MessageBoxIcon.Error);
                              Application.Exit();
                         }
               }
          }
     }
}
