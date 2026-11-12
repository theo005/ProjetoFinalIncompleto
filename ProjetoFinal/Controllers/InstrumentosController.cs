
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoFinal.Controllers
{
    public class InstrumentosController : Controller
    {
        private readonly HttpClient _httpClient;

        public InstrumentosController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7140/api/");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "ADMIN, Admin")]
        public IActionResult AdicionarInstrumentos()
        {
            return View();
        }

        // ==========================================
        // CATEGORIAS PRINCIPAIS
        // ==========================================

        public IActionResult Orgao() => View();
        public IActionResult Madeiras() => View();
        public IActionResult Metais() => View();
        public IActionResult Cordas() => View();
        public IActionResult Teclas() => View();
        public IActionResult Percussao() => View();


        // ==========================================
        // INSTRUMENTOS DE CORDAS
        // VIEW: InstrumentoCordas.cshtml
        // ==========================================

        public IActionResult Violoes() =>
            PaginaCordas("Violões",
                "Do primeiro acorde às grandes apresentações. Descubra violões com diferentes sonoridades e estilos.",
                "ACÚSTICO E ELETROACÚSTICO",
                "Cordas de nylon ou aço",
                "Modelos clássicos, folk e eletroacústicos",
                "Versatilidade para diversos estilos musicais");

        public IActionResult Guitarras() =>
            PaginaCordas("Guitarras",
                "Explore timbres, estilos e possibilidades sonoras com guitarras feitas para expressar sua personalidade musical.",
                "INSTRUMENTOS ELÉTRICOS",
                "Diferentes configurações de captadores",
                "Modelos para rock, blues, pop e outros estilos",
                "Grande variedade de timbres e efeitos");

        public IActionResult Baixos() =>
            PaginaCordas("Baixos",
                "Encontre instrumentos que dão profundidade, ritmo e personalidade à música.",
                "SONORIDADE GRAVE",
                "Modelos de quatro, cinco ou mais cordas",
                "Opções elétricas e acústicas",
                "Ideal para construir a base musical");

        public IActionResult Violinos() =>
            PaginaCordas("Violinos",
                "Descubra a expressividade de um dos instrumentos mais tradicionais da música.",
                "INSTRUMENTO CLÁSSICO",
                "Diferentes tamanhos e modelos",
                "Utilizado em orquestras e apresentações solo",
                "Sonoridade aguda e expressiva");

        public IActionResult Violas() =>
            PaginaCordas("Violas",
                "Conheça instrumentos de sonoridade encorpada, presentes em diferentes formações musicais.",
                "INSTRUMENTO CLÁSSICO",
                "Timbre mais grave que o violino",
                "Presença marcante em conjuntos de cordas",
                "Equilíbrio entre melodia e harmonia");

        public IActionResult Cellos() =>
            PaginaCordas("Cellos",
                "Explore os timbres profundos e expressivos de um instrumento cheio de personalidade.",
                "INSTRUMENTO CLÁSSICO",
                "Sonoridade grave e aveludada",
                "Utilizado em orquestras e música de câmara",
                "Ampla extensão musical");


        // ==========================================
        // INSTRUMENTOS DE MADEIRAS
        // VIEW: InstrumentoMadeiras.cshtml
        // ==========================================

        public IActionResult Flautas() =>
            PaginaMadeiras("Flautas",
                "Descubra a leveza e a delicadeza de um instrumento presente em diversos estilos musicais.",
                "INSTRUMENTO DE SOPRO",
                "Sonoridade clara e suave",
                "Modelos para diferentes níveis de aprendizado",
                "Presença em orquestras, bandas e apresentações solo");

        public IActionResult Clarinete() =>
            PaginaMadeiras("Clarinete",
                "Explore a versatilidade de um instrumento conhecido por sua ampla extensão sonora.",
                "INSTRUMENTO DE SOPRO",
                "Timbre versátil e expressivo",
                "Utilizado em bandas, jazz e orquestras",
                "Diferentes modelos e sistemas de digitação");

        public IActionResult Saxofones() =>
            PaginaMadeiras("Saxofones",
                "Encontre a personalidade sonora de um instrumento marcante em diversos gêneros musicais.",
                "INSTRUMENTO DE SOPRO",
                "Diferentes tamanhos e registros",
                "Muito utilizado no jazz, blues e pop",
                "Sonoridade forte e expressiva");

        public IActionResult Oboes() =>
            PaginaMadeiras("Oboés",
                "Conheça um instrumento de timbre único, expressivo e muito presente na música clássica.",
                "INSTRUMENTO DE SOPRO",
                "Sonoridade aguda e característica",
                "Presença importante em orquestras",
                "Instrumento de palheta dupla");

        public IActionResult Fagotes() =>
            PaginaMadeiras("Fagotes",
                "Explore os sons graves e profundos de um instrumento essencial em diversas formações orquestrais.",
                "INSTRUMENTO DE SOPRO",
                "Timbre grave e encorpado",
                "Utilizado em orquestras e conjuntos",
                "Instrumento de palheta dupla");

        public IActionResult FlautasDoces() =>
            PaginaMadeiras("Flautas Doces",
                "Uma excelente opção para conhecer o universo musical e desenvolver habilidades com instrumentos de sopro.",
                "INSTRUMENTO DE SOPRO",
                "Fácil iniciação musical",
                "Disponível em diferentes tamanhos",
                "Muito utilizada no aprendizado musical");


        // ==========================================
        // INSTRUMENTOS DE METAIS
        // VIEW: InstrumentoMetais.cshtml
        // ==========================================

        public IActionResult Trompetes() =>
            PaginaMetais("Trompetes",
                "Descubra a potência e o brilho de um instrumento marcante em bandas, orquestras e diversos estilos.",
                "INSTRUMENTO DE SOPRO",
                "Sonoridade brilhante e potente",
                "Possui três válvulas",
                "Presente no jazz, música clássica e popular");

        public IActionResult Trombones() =>
            PaginaMetais("Trombones",
                "Explore a expressividade e a versatilidade sonora de um instrumento de destaque.",
                "INSTRUMENTO DE SOPRO",
                "Possui vara deslizante",
                "Sonoridade encorpada",
                "Utilizado em bandas e orquestras");

        public IActionResult Trompas() =>
            PaginaMetais("Trompas",
                "Conheça a sonoridade envolvente e sofisticada das trompas.",
                "INSTRUMENTO DE SOPRO",
                "Timbre amplo e envolvente",
                "Possui sistema de válvulas",
                "Muito presente em orquestras");

        public IActionResult Tubas() =>
            PaginaMetais("Tubas",
                "Explore os sons graves e poderosos que sustentam diferentes formações musicais.",
                "INSTRUMENTO DE SOPRO",
                "Registro extremamente grave",
                "Grande corpo e sonoridade encorpada",
                "Presente em bandas e orquestras");

        public IActionResult Eufonios() =>
            PaginaMetais("Eufônios",
                "Descubra um instrumento de timbre suave e sonoridade rica.",
                "INSTRUMENTO DE SOPRO",
                "Timbre grave e aveludado",
                "Possui válvulas",
                "Muito utilizado em bandas");

        public IActionResult Cornets() =>
            PaginaMetais("Cornets",
                "Conheça um instrumento compacto, expressivo e de sonoridade brilhante.",
                "INSTRUMENTO DE SOPRO",
                "Sonoridade semelhante à do trompete",
                "Formato compacto",
                "Utilizado em bandas e conjuntos musicais");


        // ==========================================
        // INSTRUMENTOS DE TECLAS
        // VIEW: InstrumentoTeclas.cshtml
        // ==========================================

        public IActionResult Pianos() =>
            PaginaTeclas("Pianos",
                "Explore a riqueza sonora de um instrumento clássico e extremamente versátil.",
                "INSTRUMENTO DE TECLAS",
                "Teclas com resposta dinâmica",
                "Ampla extensão musical",
                "Presente em diversos gêneros musicais");

        public IActionResult Teclados() =>
            PaginaTeclas("Teclados",
                "Descubra possibilidades sonoras e recursos para criar diferentes estilos musicais.",
                "INSTRUMENTO ELETRÔNICO",
                "Grande variedade de timbres",
                "Recursos e acompanhamentos digitais",
                "Ideal para estudos e apresentações");

        public IActionResult PianosDigitais() =>
            PaginaTeclas("Pianos Digitais",
                "Tenha a experiência de tocar piano com recursos e praticidade da tecnologia digital.",
                "INSTRUMENTO ELETRÔNICO",
                "Teclas com sensação de piano",
                "Diferentes sons e funções",
                "Praticidade para estudar e tocar");

        public IActionResult OrgaosEletronicos() =>
            PaginaTeclas("Órgãos Eletrônicos",
                "Conheça instrumentos com sonoridade marcante e diversas possibilidades musicais.",
                "INSTRUMENTO ELETRÔNICO",
                "Diferentes registros sonoros",
                "Recursos de acompanhamento",
                "Muito utilizado em igrejas e apresentações");

        public IActionResult Sintetizadores() =>
            PaginaTeclas("Sintetizadores",
                "Crie e explore timbres únicos com instrumentos voltados à experimentação sonora.",
                "INSTRUMENTO ELETRÔNICO",
                "Criação e edição de timbres",
                "Ampla variedade de sons",
                "Muito utilizado na música eletrônica e produção musical");

        public IActionResult ControladoresMidi() =>
            PaginaTeclas("Controladores MIDI",
                "Explore ferramentas para controlar instrumentos virtuais e produzir música digitalmente.",
                "EQUIPAMENTO MUSICAL",
                "Controle de instrumentos virtuais",
                "Integração com softwares musicais",
                "Ideal para produção e gravação");


        // ==========================================
        // INSTRUMENTOS DE PERCUSSÃO
        // VIEW: InstrumentoPercussao.cshtml
        // ==========================================

        public IActionResult Baterias() =>
            PaginaPercussao("Baterias",
                "Descubra instrumentos que dão ritmo, energia e personalidade às apresentações musicais.",
                "INSTRUMENTO DE PERCUSSÃO",
                "Conjunto de tambores e pratos",
                "Diferentes configurações e tamanhos",
                "Presente no rock, pop, jazz e muito mais");

        public IActionResult Cajons() =>
            PaginaPercussao("Cajons",
                "Conheça um instrumento compacto e versátil, ideal para acompanhar diferentes estilos.",
                "PERCUSSÃO",
                "Formato compacto",
                "Timbres graves e agudos",
                "Muito utilizado em apresentações acústicas");

        public IActionResult Pandeiros() =>
            PaginaPercussao("Pandeiros",
                "Explore os ritmos e a tradição de um instrumento muito presente na música brasileira.",
                "PERCUSSÃO",
                "Instrumento leve e versátil",
                "Possui platinelas",
                "Presente no samba e em diversos ritmos");

        public IActionResult Tambores() =>
            PaginaPercussao("Tambores",
                "Descubra diferentes possibilidades rítmicas com instrumentos de percussão.",
                "PERCUSSÃO",
                "Diferentes formatos e tamanhos",
                "Produção de sons graves e agudos",
                "Utilizados em diversos estilos musicais");

        public IActionResult Xilofones() =>
            PaginaPercussao("Xilofones",
                "Explore melodias e ritmos por meio de um instrumento de percussão melódica.",
                "PERCUSSÃO MELÓDICA",
                "Possui lâminas de madeira",
                "Produz notas musicais definidas",
                "Utilizado em conjuntos e educação musical");

        public IActionResult Pratos() =>
            PaginaPercussao("Pratos",
                "Conheça instrumentos que acrescentam brilho, impacto e dinâmica à música.",
                "PERCUSSÃO",
                "Diferentes tamanhos e modelos",
                "Produzem sons metálicos",
                "Utilizados em baterias e conjuntos");


        // ==========================================
        // INSTRUMENTOS DE ÓRGÃO
        // VIEW: InstrumentoOrgao.cshtml
        // ==========================================

        public IActionResult OrgaosEletricos() =>
            PaginaOrgao("Órgãos Eletrônicos",
                "Descubra instrumentos com timbres marcantes e recursos para diferentes estilos musicais.",
                "INSTRUMENTO DE TECLAS",
                "Grande variedade de registros",
                "Recursos de acompanhamento",
                "Muito utilizado em igrejas e apresentações");

        public IActionResult OrgaosDeIgreja() =>
            PaginaOrgao("Órgãos de Igreja",
                "Conheça instrumentos tradicionais que acompanham cerimônias e apresentações musicais.",
                "INSTRUMENTO DE TECLAS",
                "Sonoridade ampla e envolvente",
                "Múltiplos registros sonoros",
                "Presença tradicional em igrejas");

        public IActionResult OrgaosDigitais() =>
            PaginaOrgao("Órgãos Digitais",
                "Explore a tradição dos órgãos com recursos modernos e tecnologia digital.",
                "INSTRUMENTO ELETRÔNICO",
                "Reprodução digital de timbres",
                "Recursos modernos",
                "Praticidade e versatilidade");


        // ==========================================
        // MÉTODOS REUTILIZÁVEIS
        // ==========================================

        private IActionResult PaginaCordas(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoCordas", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PaginaMadeiras(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoMadeiras", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PaginaMetais(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoMetais", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PaginaTeclas(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoTeclas", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PaginaPercussao(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoPercussao", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PaginaOrgao(
            string nome, string descricao, string categoria,
            string detalhe1, string detalhe2, string detalhe3)
        {
            return PrepararPagina(
                "InstrumentoOrgao", nome, descricao, categoria,
                detalhe1, detalhe2, detalhe3);
        }

        private IActionResult PrepararPagina(
            string view,
            string nome,
            string descricao,
            string categoria,
            string detalhe1,
            string detalhe2,
            string detalhe3)
        {
            ViewData["NomeInstrumento"] = nome;
            ViewData["DescricaoInstrumento"] = descricao;
            ViewData["CategoriaInstrumento"] = categoria;
            ViewData["Detalhe1"] = detalhe1;
            ViewData["Detalhe2"] = detalhe2;
            ViewData["Detalhe3"] = detalhe3;

            return View(view);
        }
    }
}
