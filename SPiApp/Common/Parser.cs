using System;
using System.Diagnostics;
using System.Text;

namespace SPiApp.Common
{
    /// <summary>
    /// A parser that can parse a text file into different tokens.
    /// </summary>
    public class Parser
    {
        private StringBuilder m_token;
        private string m_text;
        private int m_offset;

        public Parser(string text)
        {
            m_text = text;
            m_offset = 0;
        }

        private void SkipWhiteSpace(bool allowNewLine)
        {
            while (m_offset < m_text.Length && m_text[m_offset] <= ' ')
            {
                // New lines may not be allowed
                if (m_text[m_offset] == '\n' && !allowNewLine)
                {
                    return;
                }

                m_offset++;
            }
        }

        private void SkipComments()
        {
            if (m_offset >= m_text.Length)
                return;

            int cur = m_text[m_offset];

            // Can not be a comment
            if (m_offset + 1 >= m_text.Length)
                return;

            // All comments start with the same character
            if (cur == '/')
            {
                cur = m_text[m_offset + 1];

                // Double slash comments
                if (cur == '/')
                {
                    m_offset++;

                    while (m_offset < m_text.Length && cur != '\n')
                    {
                        m_offset++;
                        cur = m_text[m_offset];
                    }

                    // TODO: do we need this check?
                    if (m_offset < m_text.Length)
                    {
                        m_offset++;
                    }
                }

                // Block comments
                else if (cur == '*')
                {
                    m_offset++;

                    while (m_offset + 1 < m_text.Length && (m_text[m_offset] != '*' && m_text[m_offset + 1] != '/'))
                    {
                        m_offset++;
                    }

                    // Skip both closing characters
                    m_offset += 2;
                }
            }
        }

        private void ReadString()
        {
            if (m_text[m_offset] == '\"')
            {
                m_token.Append(m_text[m_offset]);

                while (++m_offset < m_text.Length)
                {
                    m_token.Append(m_text[m_offset]);

                    // Allows escape characters
                    if (m_text[m_offset] == '\\' && m_offset + 1 < m_text.Length)
                    {
                        if (m_text[m_offset + 1] == '\"')
                        {
                            m_offset++;
                            m_token.Append(m_text[m_offset]);
                        }
                    }
                    
                    // Actual closing of the string
                    else if (m_text[m_offset] == '\"')
                    {
                        m_offset++;
                        break;
                    }
                }
            }
        }

        private void ReadNumber()
        {
            int cur = m_text[m_offset];
            bool hasDot = false;
            bool hasNumber = false;

            // Sign character is always first
            if (cur == '-' || cur == '+')
            {
                // A sign followed by a number
                if ((m_offset + 1 < m_text.Length) && (m_text[m_offset + 1] >= '0' && m_text[m_offset + 1] <= '9'))
                {
                    hasNumber = true;
                    m_token.Append(m_text[m_offset++]);
                    m_token.Append(m_text[m_offset++]);
                    cur = m_text[m_offset];
                    
                }

                // A sign followed by a dot, followed by a number
                else if ((m_offset + 2 < m_text.Length) && m_text[m_offset + 1] == '.' && (m_text[m_offset + 1] >= '0' && m_text[m_offset + 1] <= '9'))
                {
                    hasNumber = true;
                    hasDot = true;
                    m_token.Append(m_text[m_offset++]);
                    m_token.Append(m_text[m_offset++]);
                    m_token.Append(m_text[m_offset++]);
                    cur = m_text[m_offset];
                }

                // What follows the sign is invalid
                else
                {
                    throw new Exception("The character following the sign is not a number.");
                }
            }

            // Loop over floating point variables
            do
            {
                // Regular number
                while (m_offset < m_text.Length && (m_text[m_offset] >= '0' && m_text[m_offset] <= '9'))
                {
                    hasNumber = true;
                    m_token.Append(m_text[m_offset]);
                    m_offset++;
                }

                // Floating pointer
                if (!hasDot && (m_offset + 1) < m_text.Length && m_text[m_offset] == '.')
                {
                    // Only append the first logical number
                    if (m_text[m_offset + 1] >= '0' && m_text[m_offset + 1] <= '9')
                    {
                        hasNumber = true;
                        m_token.Append(m_text[m_offset++]); // .
                        m_token.Append(m_text[m_offset++]); // 0
                    }

                    else
                    {
                        throw new Exception("The dot must be followed by a number.");
                    }
                }
            }
            while (m_offset < m_text.Length && (m_text[m_offset] >= '0' && m_text[m_offset] <= '9'));

            // NOTE: The loop above does not update the local variable.
            cur = m_text[m_offset];

            // Exponent check
            if (hasNumber && (cur == 'e' || cur == 'E'))
            {
                // What follows the exponent is invalid
                if (m_offset + 1 >= m_text.Length)
                {
                    throw new Exception("The exponent must be followed by a sign or number.");
                }

                // A number follows the exponent
                if (m_text[m_offset + 1] >= '0' && m_text[m_offset + 1] <= '9')
                {
                    m_token.Append(m_text[m_offset++]); // e
                    m_token.Append(m_text[m_offset++]); // 0
                }

                else if (m_text[m_offset + 1] == '-' || m_text[m_offset + 1] == '+')
                {
                    // What follows the exponent sign is invalid
                    if (m_offset + 2 >= m_text.Length)
                    {
                        throw new Exception("The exponent sign must be followed by a number.");
                    }

                    // A number follows the exponent
                    if (m_text[m_offset + 2] >= '0' && m_text[m_offset + 2] <= '9')
                    {
                        m_token.Append(m_text[m_offset++]); // e
                        m_token.Append(m_text[m_offset++]); // -
                        m_token.Append(m_text[m_offset++]); // 1
                    }

                    else
                    {
                        throw new Exception("The exponent sign must be followed by a number.");
                    }
                }

                // Incomplete exponent
                else
                {
                    throw new Exception("The exponent must be followed by a sign or number.");
                }

                // Regular numbers after the exponent
                while (m_offset < m_text.Length && (m_text[m_offset] >= '0' && m_text[m_offset] <= '9'))
                {
                    m_token.Append(m_text[m_offset++]);
                }
            }
        }

        private void ReadWord()
        {
            char cur = m_text[m_offset];

            // No numbers allowed!
            if ((cur >= 'a' && cur <= 'z') || (cur >= 'A' && cur <= 'Z') || cur == '_')
            {
                while (m_offset < m_text.Length)
                {
                    cur = m_text[m_offset];

                    if ((cur >= 'a' && cur <= 'z') ||
                        (cur >= 'A' && cur <= 'Z')  ||
                        (cur >= '0' && cur <= '9') ||
                        cur == '_' ||
                        /* Filenames and paths may include these! */
                        cur == '/' || cur == '\\' || cur == '.' || cur == '-'
                        )
                    {
                        m_token.Append(cur);
                        m_offset++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void ReadPunctuation()
        {
            string[] punctuations =
            {
                "+=", "-=", "*=", "/=", "&=", "|=", "++", "--",
                    "&&", "||", "<=", ">=", "==", "!="
            };

            // Punctuations have at least two characters
            if (m_offset + 1 >= m_text.Length)
            {
                return;
            }

            foreach (string punctuation in punctuations)
            {
                // Can not be this puntuation
                if (m_offset + punctuation.Length >= m_text.Length)
                    continue;

                int i;

                for (i = 0; i < punctuation.Length && (m_offset + i) < m_text.Length; i++)
                {
                    if (punctuation[i] != m_text[m_offset + i])
                    {
                        break;
                    }
                }

                // Ensure the entire punctuation matches
                if (i == punctuation.Length)
                {
                    m_token.Append(punctuation);
                    break;
                }
            }
        }

        public string GetToken(bool allowNewLine = true)
        {
            if (m_offset >= m_text.Length)
            {
                return null;
            }

            // Create a new string builder
            m_token = new StringBuilder(m_text.Length);

            // Skip whitespaces and comments
            int oldOffset;

            do
            {
                oldOffset = m_offset;
                SkipWhiteSpace(allowNewLine);
                SkipComments();
            }
            while (m_offset < m_text.Length && oldOffset != m_offset);

            if (m_offset == m_text.Length)
                return m_token.ToString();

            // Take a hold of the offset as this is used to determine if anything is read!
            oldOffset = m_offset;

            ReadString();
            if (oldOffset != m_offset)
                return m_token.ToString();

            ReadNumber();
            if (oldOffset != m_offset)
                return m_token.ToString();

            ReadWord();
            if (oldOffset != m_offset)
                return m_token.ToString();

            ReadPunctuation();
            if (oldOffset != m_offset)
                return m_token.ToString();

            if (!allowNewLine && m_text[m_offset] == '\n')
            {
                return m_token.ToString();
            }

            m_token.Append(m_text[m_offset++]);
            return m_token.ToString();
        }

        public bool IsComplete()
        {
            return (m_offset == m_text.Length);
        }

        public bool IsMatch(string match, bool allowNewLine = true)
        {
            return (match == GetToken(allowNewLine));
        }

        public bool IsInt(out int value, bool allowNewLine = true)
        {
            return int.TryParse(GetToken(allowNewLine), out value);
        }

        public bool IsFloat(out float value, bool allowNewLine = true)
        {
            return float.TryParse(GetToken(allowNewLine), out value);
        }
    }
}
