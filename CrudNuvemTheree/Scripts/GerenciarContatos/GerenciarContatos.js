
var $$ = document.querySelector.bind(document);
var listaCheckBox = [];
var oTable;

$(document).ready(function () {

    $('#btnDeletar').attr("disabled", true);

    $("#BtnSubmit").click(function () {
        var campoVazio = false;

        $(".validar").each(function () {
            if ($(this).attr('readonly') !== 'readonly' && $(this).val() === '') {
                campoVazio = true;
                $(this).addClass('has-erro');
            }
            if ($(this).attr('readonly') !== 'readonly' && $(this).val() !== '') {
                $(this).removeClass('has-erro');
            }
        });
        if (campoVazio) {
            alert('Todos os campos com * são obrigatórios.');
        } else {
            CadastrarContatos();
            //$("#Form").submit();
        }
    });

    $("#BtnEditar").click(function () {
        var campoVazio = false;

        $(".validar").each(function () {
            if ($(this).attr('readonly') !== 'readonly' && $(this).val() === '') {
                campoVazio = true;
                $(this).addClass('has-erro');
            }
            if ($(this).attr('readonly') !== 'readonly' && $(this).val() !== '') {
                $(this).removeClass('has-erro');
            }
        });
        if (campoVazio) {
            alert('Todos os campos com * são obrigatórios.');
        } else {
            EditarDadosContato();
        }
    });

    $('#BtnVoltar').on('click', function () {
        window.location = '/Home/Index';
    });
});

function AddItensDeletar(isChecked, id) {
    if (isChecked) {
        this.listaCheckBox.push(id);
        this.ContarItens();
        console.log("Lista de contatos:", this.listaCheckBox);
    } else {
        this.listaCheckBox = this.listaCheckBox.filter(item => item !== id);
        this.ContarItens();
    }
}

function ContarItens() {
    if (this.listaCheckBox !== undefined) {
        if (this.listaCheckBox.length > 0) {
            $$('[contagem-itens]').innerHTML = this.listaCheckBox.length;
            $('#btnDeletar').attr("disabled", false);
        }
        else {
            $$('[contagem-itens]').innerHTML = '';
            $('#btnDeletar').attr("disabled", true);
        }
    }
    else {
        $('#btnDeletar').attr("disabled", true);
    }
}

function DeletarContatos() {
    this.listaCheckBox.forEach(reg => {
        $.ajax({
            url: '/Home/ExcluirAgendaContatos/' + reg,
            type: 'POST',
            success: function (data) {
                $$('[contagem-itens]').innerHTML = '';
                $('#btnDeletar').attr("disabled", true);
                listaCheckBox = [];
                alert("Registro deletado com sucesso.");
                BuscarContatos();
            },
            error: function (data) {
                $$('[contagem-itens]').innerHTML = '';
                $('#btnDeletar').attr("disabled", true);
                this.listaCheckBox = [];
                alert("Não foi possível deletar o registro no momento, tente novamente mais tarde.");
                BuscarContatos();
                console.warn(data); //or whatever
            }
        });
    });
}

function BuscarContatos() {
    $.ajax({
        url: '/Home/BuscarContatos',
        type: 'GET',
        success: function (data) {
            $("#listaTipos").html(data);
            oTable = $('#TipoTable').DataTable({
                "paging": true,
                "ordering": false,
                "info": false,
                "pagingType": "simple",
                "pageLength": 10,
                "language": {
                    "url": "/Scripts/DataTables-Portugues.json"
                }
            });
        },
        error: function (data) {
            console.warn(data); //or whatever
        }
    });
}

function CadastrarContatos() {
    $.ajax({
        url: '/Home/CadastrarContatos',
        type: 'POST',
        data: $("#Form").serialize(),
        success: function (data) {
            window.location = '/Home/Index';
            alert('Contato cadastrado com sucesso.');
        },
        error: function (data) {
            alert('Não foi possível cadastrar contato no momento, por favor tente novamente mais tarde.');
            window.location = '/Home/Index';
            console.warn(data); //or whatever
        }
    });
}

function EditarDadosContato() {
    $.ajax({
        url: '/Home/EditarContatos',
        type: 'POST',
        data: $("#Form").serialize(),
        success: function (data) {
            window.location = '/Home/Index';
            alert('Dados do contato atualizado com sucesso.');
        },
        error: function (data) {
            alert('Não foi possível atualizar os dados do contato no momento, por favor tente novamente mais tarde.');
            window.location = '/Home/Index';
            console.warn(data); //or whatever
        }
    });
}

function DesabilitarContato(id) {
    $.ajax({
        url: '/Home/DesabilitarContato?Id=' + id,
        type: 'POST',
        success: function (data) {
            alert('Registro Atualizado com sucesso.');
            BuscarContatos();
        },
        error: function (data) {
            alert('Não foi possível atualizar os dados do contato no momento, por favor tente novamente mais tarde.');
            BuscarContatos();
            console.warn(data); //or whatever
        }
    });
}