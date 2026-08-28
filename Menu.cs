using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дуэль
{
    public partial class Menu : Form
    {
        GameControl game = new GameControl();
        public Menu()
        {
            InitializeComponent();
            toCreateCharacter();
        }
        public void toCreateCharacter()
        {
            groupBox_createChar.Enabled = true;
            timer_create.Enabled = true;
            timer_updStatsToCreate.Enabled = true;

            groupBox_character.Enabled = false;
            timer_updateSkills.Enabled = false;

            groupBox_charList.Enabled = false;
            timer_charSelected.Enabled = false;

            groupBox_duel.Enabled = false;
            timer_Duel.Enabled = false;
            timer_winOrLuse.Enabled = false;
        }
        public void toBattleField()
        {
            groupBox_createChar.Enabled = false;
            timer_create.Enabled = false;
            timer_updStatsToCreate.Enabled = false;

            groupBox_character.Enabled = false;
            timer_updateSkills.Enabled = false;

            groupBox_charList.Enabled = false;
            timer_charSelected.Enabled = false;

            groupBox_duel.Enabled = true;
            button_move.Enabled = false;
            timer_Duel.Enabled = true;
            timer_winOrLuse.Enabled = true;

            game.startDuel(game.GetCharList[game.GetSelected.GetIndex]);

            label_nameH.Text = game.GetDuel.Hero.GetName;
            label_sexH.Text = game.GetDuel.Hero.GetSex;
            label_levelH.Text = game.GetDuel.Hero.GetLevel.ToString();
            label_healthH.Text = game.GetDuel.Hero.GetHealth.ToString();
            label_staminaH.Text = game.GetDuel.Hero.GetStamina.ToString();
            label_powerH.Text = game.GetDuel.Hero.GetPower.ToString();
            label_agilityH.Text = game.GetDuel.Hero.GetAgility.ToString();
            label_intelligenceH.Text = game.GetDuel.Hero.GetIntelligence.ToString();
            label_luckH.Text = game.GetDuel.Hero.GetLuck.ToString();

            label_nameE.Text = game.GetDuel.Enemy.GetName;
            label_sexE.Text = game.GetDuel.Enemy.GetSex;
            label_levelE.Text = game.GetDuel.Enemy.GetLevel.ToString();
            label_healthE.Text = game.GetDuel.Enemy.GetHealth.ToString();
            label_staminaE.Text = game.GetDuel.Enemy.GetStamina.ToString();
            label_powerE.Text = game.GetDuel.Enemy.GetPower.ToString();
            label_agilityE.Text = game.GetDuel.Enemy.GetAgility.ToString();
            label_intelligenceE.Text = game.GetDuel.Enemy.GetIntelligence.ToString();
            label_luckE.Text = game.GetDuel.Enemy.GetLuck.ToString();
        }
        public void toCharList()
        {
            groupBox_createChar.Enabled = false;
            timer_create.Enabled = false;
            timer_updStatsToCreate.Enabled = false;

            groupBox_character.Enabled = false;
            timer_updateSkills.Enabled = false;

            groupBox_charList.Enabled = true;
            timer_charSelected.Enabled = true;

            groupBox_duel.Enabled = false;
            timer_Duel.Enabled = false;
            timer_winOrLuse.Enabled = false;
        }
        public void toCharacter(int index)
        {
            groupBox_createChar.Enabled = false;
            timer_create.Enabled = false;
            timer_updStatsToCreate.Enabled = false;

            groupBox_character.Enabled = true;
            timer_updateSkills.Enabled = false;

            groupBox_charList.Enabled = false;
            timer_charSelected.Enabled = false;

            groupBox_duel.Enabled = false;
            timer_Duel.Enabled = false;
            timer_winOrLuse.Enabled = false;

            game.selectChar(index);

            label_name.Text = game.GetSelected.GetName;
            label_sex.Text = game.GetSelected.GetSex;
            label_level.Text = game.GetSelected.GetLevel.ToString();

            label_healthC.Text = game.GetSelected.GetHealth.ToString();
            label_staminaC.Text = game.GetSelected.GetStamina.ToString();
            label_powerC.Text = game.GetSelected.GetPower.ToString();
            label_agilityC.Text = game.GetSelected.GetAgility.ToString();
            label_intelligenceC.Text = game.GetSelected.GetIntelligence.ToString();
            label_luckC.Text = game.GetSelected.GetLuck.ToString();
            label_points.Text = game.GetSelected.GetUpdatePoints.ToString();
            if(game.GetSelected.GetUpdatePoints > 0)
            {
                button_updateStats.Enabled = true;
            }
        }

        private void timer_create_Tick(object sender, EventArgs e)
        {
            if(textBox_Name.Text.Length > 0 && (radioButton_F.Checked || radioButton_M.Checked) 
                && (radioButton_Warrior.Checked || radioButton_Archer.Checked || radioButton_Wizard.Checked))
            {
                button_CreateCharecter.Enabled = true;
            }
            else
            {
                button_CreateCharecter.Enabled = false;
            }
        }

        private void button_CreateCharecter_Click(object sender, EventArgs e)
        {
            string sex;
            if(radioButton_F.Checked)
            {
                sex = "Женский";
            }
            else
            {
                sex = "Мужской";
            }
            int charClass;
            if(radioButton_Warrior.Checked)
            {
                charClass = 1;
            } 
            else
            {
                if(radioButton_Archer.Checked)
                {
                    charClass = 2;
                }
                else
                {
                    charClass = 3;
                }
            }
            game.CreateChar(textBox_Name.Text, sex, charClass);
            updateList();
            toCharacter(game.GetCharList.Count - 1);
            textBox_Name.Text = "";
            radioButton_F.Checked = false;
            radioButton_M.Checked = false;
            radioButton_Warrior.Checked = false;
            radioButton_Archer.Checked = false;
            radioButton_Wizard.Checked = false;
        }

        private void updateList()
        {
            listBox_Characters.Items.Clear();
            for(int i = 0; i < game.GetCharList.Count; ++i)
            {
                listBox_Characters.Items.Insert(i, game.GetCharList[i].Name + " " + game.GetCharList[i].Sex + " уровень: " + game.GetCharList[i].Level);
            }
        }

        private void timer_updStatsToCreate_Tick(object sender, EventArgs e)
        {
            label_stamina.Text = (Convert.ToInt32(label_power.Text) * 4).ToString();
            if(radioButton_Warrior.Checked)
            {
                label_health.Text = "70";
                label_power.Text = "9";
                label_agility.Text = "5";
                label_intelligence.Text = "0";
                label_luck.Text = "5";
            }
            else
            {
                if(radioButton_Archer.Checked)
                {
                    label_health.Text = "50";
                    label_power.Text = "5";
                    label_agility.Text = "8";
                    label_intelligence.Text = "0";
                    label_luck.Text = "7";
                }
                else
                {
                    label_health.Text = "50";
                    label_power.Text = "7";
                    label_agility.Text = "5";
                    label_intelligence.Text = "3";
                    label_luck.Text = "5";
                }
            }
        }

        private void button_updateStats_Click(object sender, EventArgs e)
        {
            button_healthUp.Visible = true;
            button_staminaUp.Visible = true;
            button_powerUp.Visible = true;
            button_agilityUp.Visible = true;
            button_intelligenceUp.Visible = true;
            button_luckUp.Visible = true;
            button_healthUp.Enabled = true;
            button_staminaUp.Enabled = true;
            button_powerUp.Enabled = true;
            button_agilityUp.Enabled = true;
            button_intelligenceUp.Enabled = true;
            button_luckUp.Enabled = true;

            timer_updateSkills.Enabled = true;
        }

        private void timer_updateSkills_Tick(object sender, EventArgs e)
        {
            label_healthC.Text = game.GetSelected.GetHealth.ToString();
            label_staminaC.Text = game.GetSelected.GetStamina.ToString();
            label_powerC.Text = game.GetSelected.GetPower.ToString();
            label_agilityC.Text = game.GetSelected.GetAgility.ToString();
            label_intelligenceC.Text = game.GetSelected.GetIntelligence.ToString();
            label_luckC.Text = game.GetSelected.GetLuck.ToString();
            label_points.Text = game.GetSelected.GetUpdatePoints.ToString();
            if (Convert.ToInt32(label_points.Text) == 0)
            {
                button_updateStats.Enabled = false;

                button_healthUp.Visible = false;
                button_staminaUp.Visible = false;
                button_powerUp.Visible = false;
                button_agilityUp.Visible = false;
                button_intelligenceUp.Visible = false;
                button_luckUp.Visible = false;
                button_healthUp.Enabled = false;
                button_staminaUp.Enabled = false;
                button_powerUp.Enabled = false;
                button_agilityUp.Enabled = false;
                button_intelligenceUp.Enabled = false;
                button_luckUp.Enabled = false;
                timer_updateSkills.Enabled = false;

                timer_updateSkills.Enabled = false;

            }
        }

        private void button_healthUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(1);
        }

        private void button_staminaUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(2);
        }

        private void button_powerUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(3);
        }

        private void button_agilityUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(4);
        }

        private void button_intelligenceUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(5);
        }

        private void button_luckUp_Click(object sender, EventArgs e)
        {
            game.GetSelected.updateSkill(6);
        }

        private void button_goToList_Click(object sender, EventArgs e)
        {
            toCharList();
        }

        private void timer_charSelected_Tick(object sender, EventArgs e)
        {
            if(listBox_Characters.SelectedIndex > -1)
            {
                button_submit.Enabled = true;
            }
            else
            {
                button_submit.Enabled = false;
            }
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            toCharacter(listBox_Characters.SelectedIndex);
        }

        private void button_toBattle_Click(object sender, EventArgs e)
        {
            toBattleField();
        }

        private void timer_Duel_Tick(object sender, EventArgs e)
        {
            if(radioButton_attack.Checked || radioButton_defence.Checked)
            {
                button_move.Enabled = true;
            }
            else
            {
                button_move.Enabled = false;
            }
        }

        private void button_move_Click(object sender, EventArgs e)
        {
            if(radioButton_attack.Checked)
            {
                game.GetDuel.makeAMove(1);
            }
            else
            {
                game.GetDuel.makeAMove(2);
            }
            textBox_duel.Text = "";

            textBox_duel.Text += game.GetDuel.Hero.GetName + " " + game.GetDuel.LastHeroMove + Environment.NewLine;
            textBox_duel.Text += game.GetDuel.Enemy.GetName + " " + game.GetDuel.LastEnemyMove + Environment.NewLine;

            label_healthH.Text = game.GetDuel.HeroHealth.ToString();
            label_staminaH.Text = game.GetDuel.HeroStamina.ToString();

            label_healthE.Text = game.GetDuel.EnemyHealth.ToString();
            label_staminaE.Text = game.GetDuel.EnemyStamina.ToString();
            
            radioButton_attack.Checked = false;
            radioButton_defence.Checked = false;
        }

        private void timer_winOrLuse_Tick(object sender, EventArgs e)
        {
            if(game.isBattleEnd())
            {
                if(game.duelResult() == "Победа!")
                {
                    timer_Duel.Enabled = false;
                    timer_winOrLuse.Enabled = false;
                    MessageBox.Show(game.duelResult(), "Результат боя", MessageBoxButtons.OK);
                    game.GetSelected.victory();
                    game.GetSelected.levelUp();
                    game.charSave();

                    updateList();

                    toCharacter(game.GetSelected.GetIndex);

                    textBox_duel.Text = "";
                    return;
                }
                else
                {
                    timer_Duel.Enabled = false;
                    timer_winOrLuse.Enabled = false;
                    MessageBox.Show(game.duelResult(), "Результат боя", MessageBoxButtons.OK);
                    toCharacter(game.GetSelected.GetIndex);
                    textBox_duel.Text = "";
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toCreateCharacter();
        }
    }
}
