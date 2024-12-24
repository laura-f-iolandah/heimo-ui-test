using UnityEngine.UIElements;

public class HeaderScript
{
    private Label labelTicket;
    private Button buttonTicket;
    private Label labelCoins;
    private Button buttonCoins;

    public HeaderScript(Label labelTicket, Button buttonTicket, Label labelCoins, Button buttonCoins)
    {
        this.labelTicket = labelTicket;
        this.buttonTicket = buttonTicket;
        this.labelCoins = labelCoins;
        this.buttonCoins = buttonCoins;

        buttonTicket.clicked += OnTicketButtonClick;
        buttonCoins.clicked += OnCoinsButtonClick;
    }

    private void OnTicketButtonClick()
    {
        if (int.TryParse(labelTicket.text, out int currentTicketValue))
        {
            currentTicketValue++; 
            labelTicket.text = currentTicketValue.ToString(); 
        }
        else
        {
            
            labelTicket.text = "0";
        }
    }

    
    private void OnCoinsButtonClick()
    {
        
        if (int.TryParse(labelCoins.text, out int currentCoinsValue))
        {
            currentCoinsValue++; 
            labelCoins.text = currentCoinsValue.ToString(); 
        }
        else
        {
            
            labelCoins.text = "0";
        }
    }
}
