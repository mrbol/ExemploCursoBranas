# Exemplo do Curso Branas

Este repositório foi criado para armazenar as Implementação do Projeto realizado no Curso Branas. 
Uma aplicação completa, do frontend ao backend, dividida em vários microservices utilizando TypeScript com Clean Code, Refactoring, TDD, OO, Ports and Adapters, Clean Architecture, Domain-Driven Design, Design Patterns, SOLID, Event-Driven Architecture e CQRS.
#
> *O meu objetivo é converter todo conteudo de TypeScripts para C#. A medido que eu for convertendo eu vou compartilhando aqui*.
#

### 📑 Implementação do Projeto - Parte 1 (TDD e Refactoring)
- [x] Não deve criar um pedido com cpf invalido
- [x] Deve um pedido com 3 itens( com descrição e quantidade)
- [x] Deve criar um pedido com cupom de desconto (percentual sobre total do pedido)

### 📑 Projeto - Parte 2
- [ ] Não deve aplicar cupom de desconto expirado
- [ ] Ao fazer um pedido, a quantidade de um item não pode ser negativa
- [ ] Ao fazer um pedido, o mesmo item não pode ser informado mais de uma vez
- [ ] Nenhuma dimensão do item pode ser negativa
- [ ] O peso do item não pode ser negativo
- [ ] Deve calcular o valor do frete com base nas dimensões (altura, largura e profundidade em cm) e o peso dos produtos (em kg)
- [ ] Deve retornar o preço mínimo de frete caso ele seja superior ao valor calculado
