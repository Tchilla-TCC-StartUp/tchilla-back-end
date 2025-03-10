-- 📍 Países
CREATE TABLE pais (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL UNIQUE,
    codigo_iso VARCHAR(3) NOT NULL UNIQUE -- Exemplo: "AO" para Angola, "BR" para Brasil
);

-- 📍 Estados ou Províncias
CREATE TABLE estado_provincia (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    pais_id INT REFERENCES pais(id) ON DELETE CASCADE,
    UNIQUE (nome, pais_id) -- Garante que o mesmo estado não seja cadastrado duas vezes no mesmo país
);

-- 📍 Endereços
CREATE TABLE endereco (
    id SERIAL PRIMARY KEY,
    numero VARCHAR(50) NOT NULL,
    rua VARCHAR(255) NOT NULL,
    cidade VARCHAR(100) NOT NULL,
    estado_provincia_id INT REFERENCES estado_provincia(id) ON DELETE SET NULL,
    cep VARCHAR(20), -- Opcional, dependendo do país
    latitude DECIMAL(10, 6),
    longitude DECIMAL(10, 6),
    pais_id INT REFERENCES pais(id) ON DELETE SET NULL
);

-- 🚀 Tipos de usuário
CREATE TYPE usuario_tipo AS ENUM ('cliente', 'prestador', 'agencia', 'admin');

-- 🚀 Usuários
CREATE TABLE usuario (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    senha_hash TEXT NOT NULL,
    telefone VARCHAR(20),
    tipo usuario_tipo NOT NULL,
    foto TEXT,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Relacionamento Usuário-Endereço
CREATE TABLE usuario_endereco (
    id SERIAL PRIMARY KEY,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    endereco_id INT REFERENCES endereco(id) ON DELETE CASCADE,
    UNIQUE (usuario_id, endereco_id)
);

-- 🚀 Tipos de prestador
CREATE TYPE prestador_tipo AS ENUM ('individual', 'empresa');

-- 🚀 Prestadores
CREATE TABLE prestador (
    id SERIAL PRIMARY KEY,
    nif VARCHAR(15) NOT NULL,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    descricao TEXT,
    tipo prestador_tipo NOT NULL,
    foto TEXT,
    aprovado BOOLEAN DEFAULT FALSE,
    endereco_id INT REFERENCES endereco(id) ON DELETE SET NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Agências de Eventos
CREATE TABLE agencia (
    id SERIAL PRIMARY KEY,
    nif VARCHAR(15) NOT NULL,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    descricao TEXT,
    foto TEXT,
    aprovado BOOLEAN DEFAULT FALSE,
    endereco_id INT REFERENCES endereco(id) ON DELETE SET NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Locais para Eventos
CREATE TABLE local (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    capacidade INT NOT NULL,
    preco_hora DECIMAL(10,2) NOT NULL,
    prestador_id INT REFERENCES prestador(id) ON DELETE SET NULL,
    agencia_id INT REFERENCES agencia(id) ON DELETE SET NULL,
    endereco_id INT REFERENCES endereco(id) ON DELETE SET NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Unidade de Serviço/Produto
CREATE TYPE unidade_tipo AS ENUM ('hora', 'quantidade', 'personalizado', 'unidade', 'kg');

-- 🚀 Serviços
CREATE TABLE servico (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    categoria VARCHAR(255) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    prestador_id INT REFERENCES prestador(id) ON DELETE SET NULL,
    agencia_id INT REFERENCES agencia(id) ON DELETE SET NULL,
    unidade unidade_tipo NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Produtos
CREATE TABLE produto (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    categoria VARCHAR(255) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    prestador_id INT REFERENCES prestador(id) ON DELETE SET NULL,
    agencia_id INT REFERENCES agencia(id) ON DELETE SET NULL,
    unidade unidade_tipo NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Status de Combo
CREATE TYPE combo_status AS ENUM ('ativo', 'pendente_aprovacao', 'inativo');

-- 🚀 Combos
CREATE TABLE combo (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    descricao TEXT,
    prestador_id INT REFERENCES prestador(id) ON DELETE CASCADE,
    agencia_id INT REFERENCES agencia(id) ON DELETE CASCADE,
    preco DECIMAL(10,2) NOT NULL,
    foto TEXT,
    status combo_status DEFAULT 'ativo',
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Relacionamento Combo-Serviço
CREATE TABLE combo_servico (
    id SERIAL PRIMARY KEY,
    combo_id INT REFERENCES combo(id) ON DELETE CASCADE,
    servico_id INT REFERENCES servico(id) ON DELETE CASCADE,
    quantidade INT NOT NULL DEFAULT 1
);

-- 🚀 Relacionamento Combo-Produto
CREATE TABLE combo_produto (
    id SERIAL PRIMARY KEY,
    combo_id INT REFERENCES combo(id) ON DELETE CASCADE,
    produto_id INT REFERENCES produto(id) ON DELETE CASCADE,
    quantidade INT NOT NULL DEFAULT 1
);

-- 🚀 Status de Agendamento
CREATE TYPE agendamento_status AS ENUM ('pendente', 'confirmado', 'cancelado', 'concluido');

-- 🚀 Agendamentos
CREATE TABLE agendamento (
    id SERIAL PRIMARY KEY,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    data_inicio TIMESTAMP NOT NULL,
    data_fim TIMESTAMP NOT NULL,
    status agendamento_status DEFAULT 'pendente',
    valor_total DECIMAL(10,2) NOT NULL,
    local_id INT REFERENCES local(id) ON DELETE SET NULL,
    endereco_id INT REFERENCES endereco(id) ON DELETE SET NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Avaliação de Agendamentos
CREATE TABLE avaliacao (
    id SERIAL PRIMARY KEY,
    agendamento_id INT REFERENCES agendamento(id) ON DELETE CASCADE,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    nota INT CHECK (nota >= 0 AND nota <= 5) NOT NULL,
    comentario TEXT,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Chats de Apoio
CREATE TABLE chat (
    id SERIAL PRIMARY KEY,
    agendamento_id INT REFERENCES agendamento(id) ON DELETE CASCADE,
    usuario_id INT REFERENCES usuario(id) ON DELETE CASCADE,
    mensagem TEXT NOT NULL,
    data_envio TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 🚀 Disponibilidades
CREATE TYPE disponibilidade_tipo AS ENUM ('local', 'servico', 'produto');
CREATE TYPE disponibilidade_status AS ENUM ('disponivel', 'indisponivel');

CREATE TABLE disponibilidade (
    id SERIAL PRIMARY KEY,
    tipo disponibilidade_tipo NOT NULL,
    referencia_id INT NOT NULL,
    data_inicio TIMESTAMP NOT NULL,
    data_fim TIMESTAMP NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    quantidade_disponivel INT DEFAULT NULL,
    status disponibilidade_status DEFAULT 'disponivel',
    UNIQUE (tipo, referencia_id, data_inicio, data_fim)
);


CREATE TABLE categoria_local (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL UNIQUE,
    descricao TEXT
);
CREATE TABLE categoria_servico (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL UNIQUE,
    descricao TEXT
);
CREATE TABLE categoria_produto (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(255) NOT NULL UNIQUE,
    descricao TEXT
);
ALTER TABLE local ADD COLUMN categoria_id INT REFERENCES categoria_local(id) ON DELETE SET NULL;
ALTER TABLE servico ADD COLUMN categoria_id INT REFERENCES categoria_servico(id) ON DELETE SET NULL;
ALTER TABLE produto ADD COLUMN categoria_id INT REFERENCES categoria_produto(id) ON DELETE SET NULL;
