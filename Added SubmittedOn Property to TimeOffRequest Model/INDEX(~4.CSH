    @Html.DisplayFor(modelItem => item.ActiveSchedule)
        </td>
        <td>
            @Html.DisplayFor(modelItem => item.SubmittedOn)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", new { id = item.EventID }) |
            @Html.ActionLink("Details", "Details", new { id = item.EventID }) |
            @Html.ActionLink("Delete", "Delete", new { id = item.EventID })
