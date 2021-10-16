USE SPMedicalGroup;
GO

INSERT INTO Endereco(NomeRua, Numero, Bairro, Cidade)
VALUES 
('Rua dos Trilhos', 300, 'Belem', 'São Paulo')
GO


INSERT INTO Clinica(IdEndereco, NomeClinica ,CNPJ, RazaoVisita, ClinicaAberta, ClinicaFechada)
VALUES (1,'Clinica Medica', '12345678910121', 
'Ajuda Medica', '05:00:00', '18:00:00');
GO


INSERT INTO TipoUsuario(NomeTipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente');
GO


INSERT INTO Especialidade(TipoEspecialidade)
VALUES ('Cardiologia'),('Cirurgia Cardiovascular'),
('Cirurgia da Mão'),('Cirurgia Geral'),('Cirurgia Pediatrica'),('Cirurgia Plástica')
,('Pediatria'),('Psiquiatria');
GO


INSERT INTO Usuario(IdTipoUsuario, Email, Senha)
VALUES (2,'sherlok.holmes@spmedicalgroup.com.br', '12345'),(2,'Saulo.Andrade@spmedicalgroup.com.br', '123456'),(2,'SantaMaria@spmedicalgroup.com.br','1234567'),
(3,'Kethelin@gmail.com','Kethelin123'),(3,'denis@gmail.com','denis123'),(3,'Cardoso@gmail.com','Cardosin123')
GO

INSERT INTO Paciente(IdUsuario,IdEndereco,NomePaciente,DataNascimento, Telefone, RG)
VALUES (4, 1,'Kethelin', '11-09-2000', '+5511981568091', '198156809'),
(5,1, 'Denis', '11-09-2000', '+5511981568090','326543457'),
(6, 1, 'Cardoso', '11-09-2000', '+5511981568092',	'546365253')
GO


INSERT INTO Medico(IdUsuario, IdClinica, IdEspecialidadeMedica, NomeMedico)
VALUES (1, 4, 2, 'Sherlok'),
(2, 4, 1,	'Roberto'),
(3, 4, 8,	'Helena')
GO


INSERT INTO SituacaoPaciente(Avaliacao)
VALUES ('Agendada'),('Realizada'),('Cancelada');
GO


INSERT INTO Consulta(IdPaciente, IdMedico, IdSituacaoPaciente, DataConsulta, DescricaoConsulta)
VALUES (5, 3, 1, '20210610 06:00:00 AM' , null),
(6, 4, 3, '20210610 12:00:00 PM', 'Nao compareceu a clinica'),
(7, 5, 2, '20210610 13:00:00 PM', null)
GO

SELECT * FROM Clinica
SELECT * FROM Paciente
SELECT * FROM medico
SELECT * FROM SituacaoPaciente