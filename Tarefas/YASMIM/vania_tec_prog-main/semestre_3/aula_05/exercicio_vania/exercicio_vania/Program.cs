using exercicio_vania;

Fabrica fabrica1 = new Fabrica("Fabrica 1", "Modelo 1", "15:34", "Máquina 1", DateTime.Now);
fabrica1.ListarMaquinas();

Maquina maquina2 = new Maquina("Modelo 2", "15:04", "Equipamento 2", DateTime.Now);
fabrica1.AdicionarMaquina(maquina2);
Console.WriteLine($"Adicionando a máquina modelo: {maquina2.Modelo}");
fabrica1.ListarMaquinas();