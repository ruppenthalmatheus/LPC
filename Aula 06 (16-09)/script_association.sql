CREATE TABLE cities (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    state VARCHAR(50) NOT NULL
)Engine=InnoDB;

DROP TABLE members;

CREATE TABLE members (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    idC INT NOT NULL,
    name VARCHAR(50) NOT NULL,
    CONSTRAINT FK_Cities
    FOREIGN KEY (idC) REFERENCES cities (id)
		ON UPDATE CASCADE
        ON DELETE RESTRICT
)Engine=InnoDB;

SELECT m.id, m.name, c.name FROM members M
INNER JOIN cities C ON m.idC = c.id;