//Niko Parker, CS 552

import java.applet.*;
import java.awt.*;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JCheckBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
import javax.swing.SwingUtilities;
import javax.swing.JOptionPane;
import javax.swing.JButton;
import java.text.*;

public class Icecream extends Applet
{
	private JButton clearButton;
	private JButton addToCart;
	private JButton exitButton;
	private double totalCost, toppings, subtotal, tax;
	private JCheckBox cb[] = new JCheckBox[12];

    private void GUI()
    {
		final Object[] menu = {"Chocolate Fudge", "Coffee Caramel", "Boston Cream Pie", "Vanilla Ice Cream Bar", "Chocolate Chip Cookie Dough",
 "Mint Chocolate Cookie", "Strawberry Cheesecake Cup", "Banana Split", "Peanut Butter Cup", "Raspberry Fudge Chunk"};

		for(int i = 0; i < cb.length; i++)
			cb[i] = new JCheckBox("");

		final Object brand = JOptionPane.showInputDialog(null,"Which icecream would you like?","Icecream", JOptionPane.QUESTION_MESSAGE, null, menu, "");
		if(brand == null)
			exit();
        final JFrame frame = new JFrame();
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JPanel main;

		frame.setTitle("Icecream");
        GridBagConstraints firstCol = new GridBagConstraints();
        firstCol.weightx = 1.0;
        firstCol.anchor = GridBagConstraints.WEST;
        firstCol.insets = new Insets(5, 20, 5, 5);

        GridBagConstraints lastCol = new GridBagConstraints();
        lastCol.gridwidth = GridBagConstraints.REMAINDER;
        lastCol.weightx = 1.0;
        lastCol.fill = GridBagConstraints.HORIZONTAL;
        lastCol.insets = new Insets(5, 5, 5, 20);

        main = new JPanel(new GridBagLayout());

        JLabel l_label = null;

        l_label = new JLabel("Select flavors and toppings:");
		main.add(l_label, lastCol);
        l_label = new JLabel("Chocolate Chips");
        main.add(l_label, firstCol);
		main.add(cb[0], lastCol);
        l_label = new JLabel("Marshmallow");
        main.add(l_label, firstCol);
		main.add(cb[1], lastCol);
        l_label = new JLabel("Caramel");
        main.add(l_label, firstCol);
		main.add(cb[2], lastCol);
        l_label = new JLabel("Chocolate Sauce");
        main.add(l_label, firstCol);
		main.add(cb[3], lastCol);
        l_label = new JLabel("Hot Fudge");
        main.add(l_label, firstCol);
		main.add(cb[4], lastCol);
        l_label = new JLabel("Almonds");
        main.add(l_label, firstCol);
		main.add(cb[5], lastCol);
        l_label = new JLabel("M&M's®");
        main.add(l_label, firstCol);
		main.add(cb[6], lastCol);
        l_label = new JLabel("Strawberry");
        main.add(l_label, firstCol);
		main.add(cb[7], lastCol);
        l_label = new JLabel("Gummy Bears");
        main.add(l_label, firstCol);
		main.add(cb[8], lastCol);
        l_label = new JLabel("Pineapple");
        main.add(l_label, firstCol);
		main.add(cb[9], lastCol);
        l_label = new JLabel("Walnuts");
        main.add(l_label, firstCol);
		main.add(cb[10], lastCol);
        l_label = new JLabel("Peanut Butter");
        main.add(l_label, firstCol);
		main.add(cb[11], lastCol);

		clearButton = new JButton("Clear");
		main.add(clearButton, firstCol);
    	clearButton.addActionListener
    	(
        	new ActionListener()
        	{
            public void actionPerformed(ActionEvent e)
            	{
                	clear();
            	}
        	}
    	);

    	addToCart = new JButton("Add To Cart");
		main.add(addToCart, lastCol);
    	addToCart.addActionListener(new ActionListener()
    	{
        public void actionPerformed(ActionEvent e)
        	{
			int chk = 0;
    		for(int i = 0; i < cb.length; i++)
    		{
    			if(cb[i].isSelected() == true)
    				chk++;
    			if(chk > 3)
    			{
					JOptionPane.showMessageDialog(null, "Select no more than 3 toppings.", "Error", JOptionPane.ERROR_MESSAGE);
					clear();
					break;
				}
			}
            flavor();

            DecimalFormat df = new DecimalFormat("0.00");

             if(e.getSource() == addToCart && chk <= 3 )
             {
                JOptionPane.showMessageDialog(null, brand + "\nSubtotal: $" + df.format(1.00 + toppings) + "\nTax: $" + df.format(tax) + "\nTotal balance: $" + df.format(totalCost), "Total", JOptionPane.INFORMATION_MESSAGE);
                frame.dispose();
			}
        	}
    	});

    	exitButton = new JButton("Close");
    	main.add(exitButton, firstCol);
     	exitButton.addActionListener
    	(
        	new ActionListener()
        	{
            	public void actionPerformed(ActionEvent e)
            	{
                	exit();
            	}
        	}
    	);
        frame.add(main);
        frame.pack();
        frame.setVisible(true);
    }

 private void flavor()
	{
	for(int i = 0; i < 12; i++)
    	if(cb[i].isSelected())
        	toppings = toppings + .30;

  	subtotal = 1.00 + toppings;
  	tax = subtotal / 10;
  	totalCost = subtotal + tax;
	}

    private void clear()
	{
	for(int i = 0; i < cb.length; i++)
    	cb[i].setSelected(false);
	}

private void exit()
{
    System.exit(0);
}

public static void main(String args[])
{

      new Icecream().GUI();
}
}