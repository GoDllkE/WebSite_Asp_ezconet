DROP TABLE Usuario;
DROP TABLE Sexo;

CREATE TABLE Sexo (
	SexoId		INT				NOT NULL	PRIMARY KEY		IDENTITY(1,1),
	Nome		VARCHAR(15)		NOT NULL
)


CREATE TABLE Usuario (
	UsuarioId			INT				NOT NULL	PRIMARY KEY		IDENTITY(1,1),
	Nome				VARCHAR(200)	NOT NULL,
	DataNascimento		DATE			NULL,
	Email				VARCHAR(100)	NOT NULL,
	Senha				VARCHAR(30)		NOT NULL,
	Ativo				INT				NOT NULL,
	SexoId				INT				NOT NULL	FOREIGN KEY REFERENCES Sexo(SexoId)
);
*/

INSERT INTO Sexo (nome) VALUES 
('Masculino'),
('Feminino'),
('Indefinido'),
('Alienígena'),
('Outro');


INSERT INTO Usuario (Nome, DataNascimento, Email, Senha, Ativo, SexoId) VALUES 
('teste',GETDATE(),'teste@ezconet.com','123456',1,1),
('asdfg',GETDATE(),'asdfg@ezconet.com','123456',1,2),
('gfdsa',GETDATE(),'gfdsa@ezconet.com','123456',1,4);


SELECT * FROM Sexo;
SELECT * FROM Usuario;