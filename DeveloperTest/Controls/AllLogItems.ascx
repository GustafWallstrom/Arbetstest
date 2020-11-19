<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AllLogItems.ascx.cs" Inherits="DeveloperTest.Controls.AllLogItems" %>
<%@ Import Namespace="DeveloperTest.DAL" %>
<div class="row">
    <div class="c6 clms">
        <a href="<%# Core.Base.CustomPage.Get(4).PageLink %>" class="btn block">Skapa nytt ärende</a>
    </div>
    <div class="c6 clms">
        <asp:Button runat="server" ID="exportAll" OnClick="exportAll_Click" Text="Exportera alla till Excel" />
    </div>
</div>
<div class="row">
    <div class="c6 clms">
        <input type="text" id="csearch" placeholder="Sök här..." class="conflictsearch" />
        
    </div>
    <div class="c6 clms">
        <div class="selyear">
            <asp:Label runat="server" ID="exyearlbl" AssociatedControlID="exyearsel" Text="Välj år"></asp:Label>
            <asp:DropDownList runat="server" ID="exyearsel" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="exyearsel_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
</div>

<asp:Repeater runat="server" ID="exItems">
    <HeaderTemplate>
        <div class="cf mt20" id="orgconf">
            <div class="row">
                <div class="c1 clms"><strong>ID</strong></div>
                <div class="c3 clms">
                    <strong>Svarande</strong>
                </div>
                <div class="c8 clms">
                    <strong>Fråga</strong>
                </div>
            </div>
    </HeaderTemplate>
    <ItemTemplate>
        <div class="rcinfo">
            <div class="row cf personrow">
                <div class="c1 clms">
                    <span class="cnametit">
                        <%# ((LogItem)Container.DataItem).Id %></span>
                </div>
                <div class="c3 clms">
                    <%# ((LogItem)Container.DataItem).User%>
                </div>
                <div class="c8 clms">
                    <%# ((LogItem)Container.DataItem).Question%>
                </div>
            </div>
            <div class="cf">
                <div class="btn openconflict" data-id="<%# ((LogItem)Container.DataItem).Id %>">Visa hela</div>
            </div>
        </div>
    </ItemTemplate>
    <FooterTemplate>
        </div>
    </FooterTemplate>
</asp:Repeater>

<div id="csresult" style="display: none;">
    <div class="cf mt20" id="orgconf">
        <div class="row">
            <div class="c1 clms"><strong>ID</strong></div>
            <div class="c3 clms">
                <strong>Svarande</strong>
            </div>
            <div class="c8 clms">
                <strong>Fråga</strong>
            </div>
        </div>
    </div>
    <div id="cresbody">
        
    </div>
</div>

<script>
  ql.postload([
    '/js/base.js',
    '/js/moment.js'
  ], function () {
    const element = {
      doc: $(document.body),
      ctable: $('#ctable tbody'),
      del: $('#delrow'),
      edit: $('#editrow'),
      csearch: $('#csearch'),
      org: $('#orgconf'),
      res: $('#csresult'),
      resbody: $('#cresbody')
    };

    function openLog(logItem) {
      element.del.attr('data-id', logItem.Id);
      element.edit.attr('data-id', logItem.Id);
      element.ctable.empty();

      let tr = $('<tr />');

      Object.keys(logItem).filter(key => key !== '__type').forEach(key => {
        let td = $('<td />');
        let val = logItem[key];

        if (moment.isDate(val)) {
          val = moment(val).format("YYYY-MM-DD HH:mm");
        }

        td.append(val).appendTo(tr);
      });

      tr.appendTo(element.ctable);
      $('.cov').ov({ width: '1200' });
    }

    element.doc.on('click', '.openconflict', function () {
      let id = $(this).data('id') - 0;
      helper.logService.get(id).then(openLog);
    });

    element.doc.on('click', '#delrow', () => {
      let id = $(this).data('id');
      let text = 'Är du säker på att du vill ta bort hela raden?\nValet är permanent och går inte att ångra.';

      if (confirm(text)) {
        helper.logService.delete(id).then(removed => {
          if (removed) {
            location.reload();
          } else {
            alert('Kunde inte ta bort rad, försök igen');
          }
        });
      }
    });

    element.doc.on('click', '#editrow', function () {
      let id = $(this).data('id');
      let link = '<%# Core.Base.CustomPage.Get(4).PageLink %>';
      window.location.href = link + '?edit=' + id;
    });

    element.csearch.keyup(helper.debounce(function () {
      let val = (element.csearch.val() + '').toLowerCase().trim();
      element.resbody.empty();

      if (!val) {
        element.org.fadeIn();
        element.res.hide();
        return;
      }

      helper.logService.search(val).then(result => {
        result.forEach(item => {
          let rc = $('<div class="rcinfo" />');
          let prow = $('<div class="personrow" />').appendTo(rc);

          prow.append(`<div class="c1 clms"><span class="cnametit">${item.Id}</span></div>`);
          prow.append(`<div class="c3 clms">${item.User}</div>`);
          prow.append(`<div class="c8 clms">${item.Question}</div>`);

          rc.append(`<div class="cf"><div class="btn openconflict" data-id="${item.Id}">Visa hela</div></div>`);
          rc.appendTo(element.resbody);
        });

        element.org.hide();
        element.res.fadeIn();
      });
    }, 500));

  });
</script>