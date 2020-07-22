using CRD.AplicationCore.Interfaces.Validations;
using System.Text;

namespace CRD.AplicationCore.Validations
{
    public class GeneralValidationService: IGeneralValidationService
    {
        public bool IsEmptyText(string text)
        {
            bool isEmpty = false;

            if (text == "" || text == null)
                isEmpty = true;

            if (!isEmpty)
            {
                StringBuilder nameSpacesDeleted = new StringBuilder(50);

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] != ' ')
                        nameSpacesDeleted.Append(text[i]);
                }

                if (nameSpacesDeleted.Length == 0)
                    isEmpty = true;
            }
            return isEmpty;
        }

        public string GetRewrittenTextFirstCapitalLetter(string text)
        {
            if (!this.IsEmptyText(text))
            {
                text = text.ToLower();


                StringBuilder rightName = new StringBuilder();

                int nameLenght = text.Length;
                for (int i = nameLenght - 1; i > 0; i--)
                {
                    if (text[i] != ' ')
                        break;

                    nameLenght--;
                }

                int FirstLetterPosition = 0;

                foreach (var caracter in text)
                {
                    if (caracter != ' ')
                        break;

                    FirstLetterPosition++;
                }

                for (int i = FirstLetterPosition; i < nameLenght; i++)
                {
                    rightName.Append(text[i]);
                }

                string[] words = rightName.ToString().Split(' ');
                rightName.Clear();

                foreach (var word in words)
                {
                    var fixedWord = GetWordFirstCapitalLetter(word);
                    rightName.Append(fixedWord);
                    rightName.Append(" ");
                }


                rightName.Length--;
                return rightName.ToString();
            }
            return string.Empty;
        }

        private string GetWordFirstCapitalLetter(string word)
        {
            var rightWord = new StringBuilder();

            rightWord.Append(word[0].ToString().ToUpper());

            for (int i = 1; i < word.Length; i++)
            {
                rightWord.Append(word[i]);
            }

            return rightWord.ToString();
        }

    }
}
