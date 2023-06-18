CREATE TABLE [dbo].[usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[correo] [varchar](255) NOT NULL,
	[clave] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarUsuario]    Script Date: 12/06/2023 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_RegistrarUsuario](
@Correo varchar(100),
@Clave varchar(500),
@Registrado bit output,
@Mensaje varchar(100) output
)
as
begin
	if (not exists(select * from USUARIO where correo = @Correo))
	begin
		insert into USUARIO (correo, clave) values (@Correo, @Clave)
		set @Registrado = 1
		set @Mensaje = 'usuario registrado'
	end
	else
	begin
		set @Registrado = 0
		set @Mensaje = 'correo ya existe'
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_ValidarUsuario]    Script Date: 12/06/2023 20:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ValidarUsuario](
@correo varchar (100),
@clave varchar (500)
)
as 
begin
 if (exists(select* from usuario where correo=@Correo and clave=@Clave))
	select idUsuario from usuario where  correo=@Correo and clave=@Clave
	else
	select '0'
end
GO