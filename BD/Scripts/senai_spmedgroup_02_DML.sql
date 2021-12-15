USE SPMedicalGroup;
GO

INSERT INTO Endereco(NomeRua, Numero, Bairro, Cidade)
VALUES 
('Rua dos Trilhos', 300, 'Belem', 'São Paulo')
GO


INSERT INTO Clinica(IdEndereco, NomeClinica ,CNPJ, RazaoVisita, ClinicaAberta, ClinicaFechada)
VALUES (1,'Clinica Medica', '12345678910121', 'Ajuda Medica', '05:00:00', '18:00:00');
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
VALUES (2,'sherlok.holmes@spmedicalgroup.com.br', '12345'),
       (3,'Kethelin@gmail.com','Kethelin123'),
       (1,'denis@gmail.com','denis123');
GO

INSERT INTO Paciente(IdUsuario,IdEndereco,NomePaciente,DataNascimento,RG)
VALUES (3, 1,'Kethelin', '11-09-2000', '198156809'),
(1,1, 'Denis', '11-09-2000','326543457');
GO


INSERT INTO Medico(IdUsuario, IdClinica, IdEspecialidadeMedica, NomeMedico)
VALUES (1, 1, 2, 'Sherlok');
GO

TRUNCATE TABLE medico


INSERT INTO SituacaoPaciente(Avaliacao)
VALUES ('Agendada'),('Realizada'),('Cancelada');
GO


INSERT INTO Consulta(IdPaciente, IdMedico, IdSituacaoPaciente, DataConsulta, DescricaoConsulta)
VALUES (3, 1, 1, '20210610 06:00:00 AM' , null);
GO

SELECT * FROM Endereco;
SELECT * FROM Clinica;
SELECT * FROM TipoUsuario;
SELECT * FROM Especialidade
SELECT * FROM Usuario 
SELECT * FROM Paciente;
SELECT * FROM Medico;
SELECT * FROM SituacaoPaciente;
SELECT * FROM Consulta;