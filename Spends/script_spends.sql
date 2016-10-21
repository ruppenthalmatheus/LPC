CREATE TABLE Categories (
	idCategory INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
)engine=InnoDB;

CREATE TABLE Locations (
	idLocation INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    description VARCHAR(50) NOT NULL
)engine=InnoDB;

CREATE TABLE Spends (
	idSpend INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    idLocation INT NOT NULL,
    idCategory INT NOT NULL,
    spendDate DATE,
    total DECIMAL (18,2),
    CONSTRAINT FK_Location
    FOREIGN KEY (idLocation) REFERENCES Locations (idLocation)
		ON DELETE RESTRICT
        ON UPDATE CASCADE,
	CONSTRAINT FK_Categorie
    FOREIGN KEY (idCategory) REFERENCES Categories (idCategory)
		ON DELETE RESTRICT
        ON UPDATE CASCADE
)engine=InnoDB;

DROP TABLE Spends;
DROP TABLE Categories;