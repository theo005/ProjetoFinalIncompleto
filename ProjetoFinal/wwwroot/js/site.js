/*
    FUNÇÃO PARA ABRIR E FECHAR OS SUBMENUS
*/

const botoesMenu = document.querySelectorAll(".item-menu-botao");

botoesMenu.forEach(function (botao) {

    botao.addEventListener("click", function () {

        // Fecha os outros submenus
        botoesMenu.forEach(function (outroBotao) {

            if (outroBotao !== botao) {

                outroBotao.classList.remove("aberto");

                const outroSubmenu = outroBotao.nextElementSibling;

                outroSubmenu.classList.remove("aberto");
            }

        });

        // Pega o submenu deste botão
        const submenu = botao.nextElementSibling;

        // Abre/fecha o submenu
        submenu.classList.toggle("aberto");
        botao.classList.toggle("aberto");

    });

});