# MediCare BackEnd

## 📘 Introdução

A **MediCare API** é uma interface REST desenvolvida para gerenciar medicamentos, agendamentos e usuários de forma eficiente, segura e escalável. A aplicação foi projetada com foco em apoiar pacientes e profissionais da saúde no controle de tratamentos, possibilitando o cadastro de usuários, autenticação via token, registro de medicamentos e gerenciamento de agendamentos.

Esta documentação descreve os principais endpoints da API, incluindo os métodos HTTP utilizados, parâmetros esperados e formato das requisições. Todos os recursos sensíveis da API estão protegidos por autenticação baseada em tokens JWT.

## ⚙️ Tecnologias Utilizadas

A API MediCare foi construída com uma stack tecnológica moderna e hospedada em ambiente em nuvem, garantindo confiabilidade e performance:

- **.NET 8.0**  
  Framework utilizado para o desenvolvimento da API, oferecendo recursos avançados para criação de aplicações web de alto desempenho.

- **Entity Framework Core**  
  ORM utilizado para facilitar o mapeamento objeto-relacional, reduzindo a complexidade na manipulação dos dados persistidos.

- **PostgreSQL (via Neon)**  
  Banco de dados relacional utilizado pela aplicação, provisionado através do serviço [Neon](https://neon.tech), que oferece PostgreSQL escalável, com integração nativa à nuvem Azure.

- **Microsoft Azure**  
  Plataforma em nuvem responsável pela hospedagem da API, garantindo alta disponibilidade, escalabilidade automática e integração com diversos serviços essenciais para o backend.


## 📘 Documentação da API MediCare

### Obtém o token de autenticação

```http
POST /Authentication/login
```

| Parameter  | Type     | Description                                        |
|:-----------|:---------|:---------------------------------------------------|
| `email`    | `string` | **Required**. Email do usuário para autenticação   |
| `senha`    | `string` | **Required**. Senha do usuário no sistema          |

---

### Cadastro de novo usuário

```http
POST /Authentication
```

| Parameter           | Type     | Description                                        |
|:--------------------|:---------|:---------------------------------------------------|
| `nome`              | `string` | **Required**. Nome do usuário                      |
| `sobrenome`         | `string` | **Required**. Sobrenome do usuário                 |
| `email`             | `string` | **Required**. Email para cadastro no sistema       |
| `senha`             | `string` | **Required**. Senha utilizada na autenticação      |
| `senhaConfirmacao`  | `string` | **Required**. Confirmação da senha                 |

---

### Cadastrar um medicamento

```http
POST /Medicamento
```

| Parameter           | Type     | Description                                        |
|:--------------------|:---------|:---------------------------------------------------|
| `nome`              | `string` | **Required**. Nome do medicamento                  |
| `quantidade`        | `int`    | **Required**. Quantidade do medicamento            |
| `dosagem`           | `string` | **Required**. Dosagem do medicamento               |
| `horario`           | `string` | **Optional**. Horário de uso                       |
| `tempoDeTratamento` | `string` | **Optional**. Tempo estimado de tratamento         |
| `dataRegistro`      | `string` | **Optional**. Data do registro                     |

---

### Listar medicamentos

```http
GET /Medicamento
```

| Parameter              | Type     | Description                                |
|:------------------------|:---------|:--------------------------------------------|
| `pagina`               | `int`    | Número da página (default = 1)              |
| `quantidadePorPagina`  | `int`    | Quantidade por página (default = 10)        |

---

### Obter um medicamento por ID

```http
GET /Medicamento/{id}
```

| Parameter | Type     | Description                        |
|:----------|:---------|:-----------------------------------|
| `id`      | `uuid`   | **Required**. ID do medicamento    |

---

### Atualizar um medicamento

```http
PUT /Medicamento/{id}
```

| Parameter           | Type     | Description                                        |
|:--------------------|:---------|:---------------------------------------------------|
| `id`                | `uuid`   | **Required**. ID do medicamento                    |
| `nome`              | `string` | **Required**. Nome do medicamento                  |
| `quantidade`        | `int`    | **Required**. Quantidade do medicamento            |
| `dosagem`           | `string` | **Required**. Dosagem do medicamento               |
| `horario`           | `string` | **Optional**. Horário de uso                       |
| `tempoDeTratamento` | `string` | **Optional**. Tempo estimado de tratamento         |
| `dataRegistro`      | `string` | **Optional**. Data do registro                     |

---

### Excluir um medicamento

```http
DELETE /Medicamento/{id}
```

| Parameter | Type     | Description                        |
|:----------|:---------|:-----------------------------------|
| `id`      | `uuid`   | **Required**. ID do medicamento    |

---

### Cadastrar agendamento

```http
POST /Agendamento
```

| Parameter       | Type     | Description                            |
|:----------------|:---------|:----------------------------------------|
| `horario`       | `string` | **Optional**. Horário do agendamento    |
| `frequencia`    | `string` | **Optional**. Frequência do uso         |
| `medicamentoId` | `uuid`   | **Required**. ID do medicamento         |

---

### Listar agendamentos

```http
GET /Agendamento
```

| Parameter              | Type     | Description                                |
|:------------------------|:---------|:--------------------------------------------|
| `pagina`               | `int`    | Número da página (default = 1)              |
| `quantidadePorPagina`  | `int`    | Quantidade por página (default = 10)        |

---

### 🔐 Autenticação

Todos os endpoints protegidos requerem um token JWT no cabeçalho:

```http
Authorization: Bearer {seu_token}
```
