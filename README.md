# 2026-topicos-especiais-em-sistemas
Repositório com o projetos da disciplina de Tópicos Especiais em Sistemas
# LocalNet Messenger - Sistema de Mensagens em Rede Local

## 👥 Integrantes
Walter Potma de Brito
Rgm 43101607
walter.brito@cs.up.edu.br

Luiz Fernando Chaim
RGM 41578139
luiz.chaim@cs.up.edu.br

Pedro Henrique Becker De Oliveira Felix
RGM 41805640
pedro.henrique005@cs.up.edu.br

Othon Augusto Freitas Nascimento 
RGM 41606124
othon.nascimento@cs.up.edu.br

**Curso:** Análise e Desenvolvimento de Sistemas (ADS)

**Turma:** Segunda-Feira - Sala 402 - 3°N

**Matéria:** Tópicos Especiais em Sistemas - C#

---

## 📝 Resumo

O LocalNet Messenger é uma aplicação desenvolvida em C# voltada para a comunicação instantânea em ambientes de rede local (LAN). O sistema situa-se em uma zona híbrida entre um chat dinâmico e um mural de recados digital, permitindo que usuários conectados à mesma infraestrutura de rede troquem informações de maneira ágil e centralizada. O foco principal do projeto é oferecer uma interface simplificada para o fluxo de mensagens, garantindo que a comunicação interna seja mantida sem a necessidade de dependências externas ou conexão com a internet de larga escala.

---

## 🚀 Funcionalidades
*Listagem produzida com auxílio de IA.*

* **Controle de Acesso:** Sistema de entrada para usuários registrados.
* **Autenticação de Identidade:** Validação de credenciais para garantir a segurança das sessões.
* **Escrita de Mensagens (Mural):** Capacidade de redigir e enviar mensagens em tempo real para o servidor local.
* **Leitura e Visualização:** Interface de exibição cronológica das mensagens enviadas pelos participantes da rede.
* **Comunicação em Rede Local:** Arquitetura preparada para tráfego de dados via protocolo TCP/IP ou similar em ambiente LAN.

---

## 🔍 Descrição das Funcionalidades
*Redação elaborada com auxílio de IA.*

### 1. Login e Autenticação
Esta funcionalidade gerencia o ciclo de vida da sessão do usuário. Ao iniciar a aplicação, o sistema solicita credenciais que são validadas contra uma base de dados (ou estrutura de dados em memória), permitindo o acesso apenas a membros autorizados da equipe. Isso assegura a integridade das interações no mural.

### 2. Escrita de Mensagens
O módulo de escrita permite a composição de textos curtos que são enviados ao módulo central do sistema. A implementação em C# trata o encapsulamento da mensagem, associando o conteúdo ao autor e ao carimbo de data/hora (timestamp), enviando os dados para que fiquem disponíveis aos demais usuários.

### 3. Leitura e Mural de Mensagens
Atuando como um receptor de dados, esta funcionalidade atualiza a interface do usuário com as novas mensagens disponíveis. O sistema organiza as entradas de forma que o fluxo de leitura seja intuitivo, assemelhando-se a um mural eletrônico onde o histórico recente é priorizado para consulta imediata.

---

## 🤖 Uso de IA
Este projeto utilizou Inteligência Artificial para a elaboração da documentação técnica, conforme as diretrizes da disciplina.

* **Ferramenta utilizada:** Google Gemini.
* **Forma de uso:** Foram fornecidos o escopo do projeto (sistema de mensagens/mural em rede local) e os requisitos iniciais (login, autenticação, escrita e leitura). A IA foi utilizada para expandir esses conceitos em um resumo executivo profissional e detalhar tecnicamente cada funcionalidade, seguindo o padrão de documentação de repositórios como o *eShopOnWeb*.
* **Revisões realizadas pela equipe:** A equipe revisou os textos para garantir que a descrição do sistema híbrido (chat/mural) estivesse fiel à arquitetura implementada e corrigiu os nomes dos integrantes e dados do curso.---"
