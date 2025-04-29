namespace OrganizePro.Shared;

public static class Utilities
{
    public static void ShowMessage(string message, string title)
    {
        MessageBox.Show(
           message,
           title,
           MessageBoxButtons.OK,
           MessageBoxIcon.Warning
         );
    }

    public static DialogResult ConfirmAction(string message, string title)
    {
        DialogResult result = MessageBox.Show(
            message,
            title,
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning
        );

        return result;
    }

    public static int GetSelectedId(this DataGridView dgv, DataGridViewCellEventArgs e, string cell)
    {
        if (e.RowIndex >= 0)
        {
            return Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[cell].Value);
        }

        return -1;
    }

    public static void FormatNumericInput(KeyPressEventArgs e)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    public static void FormatDecimalInput(KeyPressEventArgs e, string value)
    {
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            e.Handled = true;
        }

        if (e.KeyChar == '.' && value.Contains("."))
        {
            e.Handled = true;
        }
    }

    public static void FormatPhoneInput(KeyPressEventArgs e)
    {
        if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
        {
            e.Handled = true;
        }
    }

    public static bool CheckForNulls(List<TextBox> inputs)
    {
        if (inputs.Any(input => string.IsNullOrWhiteSpace(input.Text)))
        {
            ShowMessage(
                "Please enter a value for all fields.",
                "Invalid Input"
            );

            return false;
        }

        return true;
    }

    public static List<TextBox> TrimFields(List<TextBox> inputs)
    {
        foreach (TextBox input in inputs)
        {
            input.Text = input.Text.Trim();
        }

        return inputs;
    }
}
