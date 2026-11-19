-- Script do banco do projeto atv1_3Etapa_HayatoDaviMiyamoto
-- Execute no MySQL do Wamp (phpMyAdmin > SQL, ou prompt de comando)

CREATE DATABASE IF NOT EXISTS db_delivery;
USE db_delivery;

-- Parte 2: tabela de produtos
-- (Se der erro de collation por usar MariaDB, apague a parte "COLLATE=utf8mb4_0900_ai_ci")
CREATE TABLE IF NOT EXISTS `produtos` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `preco` decimal(10,2) NOT NULL,
  `categoria` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4
COLLATE=utf8mb4_0900_ai_ci;

-- Parte 4: tabela de usuários (acesso administrativo)
CREATE TABLE IF NOT EXISTS `usuarios` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(100) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `senha` VARCHAR(50) NOT NULL,
  `endereco` VARCHAR(255) NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email_UNIQUE` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Parte 5: tabela de pedidos importados do site
CREATE TABLE IF NOT EXISTS pedidos (
  id INT NOT NULL AUTO_INCREMENT,
  codigo_pedido VARCHAR(50) NOT NULL,
  nome_cliente VARCHAR(100) NOT NULL,
  total DECIMAL(10,2) NOT NULL,
  status VARCHAR(50) NOT NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- Usuário administrador de TESTE para entrar no sistema (troque se quiser)
INSERT INTO usuarios (nome, email, senha)
VALUES ('Administrador', 'admin@delivery.com', '123456');
