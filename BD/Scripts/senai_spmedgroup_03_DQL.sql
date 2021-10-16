USE SPMedicalGroup;
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


SELECT NomePaciente 'Prontuário', NomeMedico 'Médico', FORMAT(DataConsulta, 'dd/MM/yyyy hh.mm') 'Data da Consulta', Avaliacao, NomeClinica 'Clinica', Endereco.NomeRua, Endereco.Numero, Endereco.Cidade
FROM Consulta
INNER JOIN Medico
ON Medico.IdMedico = Consulta.IdMedico
InNER JOIn Clinica
ON Clinica.IdClinica = Medico.IdClinica
INNER JOIN Endereco
On Endereco.IdEndereco = Clinica.IdEndereco
INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdPaciente
INNER JOIN Endereco E
ON E.IdEndereco = Paciente.IdEndereco
INNER JOIN SituacaoPaciente
ON SituacaoPaciente.IdSituacaoPaciente = Consulta.IdSituacaoPaciente
ORDER BY Consulta.IdConsulta asc;
GO



SELECT COUNT(IdUsuario) 'Quantidade de usuários' FROM Usuario;
GO