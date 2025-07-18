USE [DBAmostras]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 13/07/2025 22:24:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Status] ON 

INSERT [dbo].[Status] ([Id], [Descricao]) VALUES (1, N'EM ANÁLISE')
INSERT [dbo].[Status] ([Id], [Descricao]) VALUES (2, N'PENDENTE')
INSERT [dbo].[Status] ([Id], [Descricao]) VALUES (3, N'FINALIZADA')
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
