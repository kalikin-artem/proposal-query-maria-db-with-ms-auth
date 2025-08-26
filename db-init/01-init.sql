CREATE TABLE IF NOT EXISTS widgets (
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  name VARCHAR(100) NOT NULL
);
INSERT INTO widgets (name) VALUES
 ('Alpha'),('Beta'),('Gamma'),('Delta'),('Epsilon')
ON DUPLICATE KEY UPDATE name = VALUES(name);
