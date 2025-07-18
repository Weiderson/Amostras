USE [DBAmostras]
GO
/****** Object:  Table [dbo].[Amostras]    Script Date: 13/07/2025 22:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Amostras](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [nvarchar](max) NOT NULL,
	[Descricao] [nvarchar](150) NOT NULL,
	[DataRecebimento] [datetime2](7) NOT NULL,
	[StatusId] [int] NOT NULL,
 CONSTRAINT [PK_Amostras] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Amostras] ON 

INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (1, N'AB00001', N'Amostra de Testes 1', CAST(N'2025-07-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (2, N'AB00002', N'Amostra de Testes 2', CAST(N'2025-07-13T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (3, N'AB00003', N'Amostra de Testes 3', CAST(N'2025-07-14T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (4, N'AB00004', N'Amostra de Testes 4', CAST(N'2025-07-09T00:00:00.0000000' AS DateTime2), 2)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (5, N'AB00005', N'Amostra de Testes 5', CAST(N'2025-07-13T20:53:21.1915074' AS DateTime2), 1)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (7, N'AB00006', N'Amostra de Testes 6', CAST(N'2025-07-13T21:18:05.3178637' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (8, N'AB00008', N'Amostra de Testes 8', CAST(N'2025-05-01T00:00:00.0000000' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (9, N'AB00009', N'Amostra de Testes 9', CAST(N'2025-07-13T21:29:42.2898366' AS DateTime2), 3)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (10, N'AB00011', N'Amostra de Testes 10', CAST(N'2025-07-13T21:32:24.1386085' AS DateTime2), 1)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (11, N'AB00012', N'Amostra de Testes 12', CAST(N'2025-07-13T21:34:18.0185850' AS DateTime2), 1)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (12, N'AB00013', N'Amostra de Testes 13', CAST(N'2025-06-30T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Amostras] ([Id], [Codigo], [Descricao], [DataRecebimento], [StatusId]) VALUES (13, N'AB00014', N'Amostra de Testes 14', CAST(N'2025-07-11T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Amostras] OFF
GO
ALTER TABLE [dbo].[Amostras]  WITH CHECK ADD  CONSTRAINT [FK_Amostras_Status_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Amostras] CHECK CONSTRAINT [FK_Amostras_Status_StatusId]
GO
