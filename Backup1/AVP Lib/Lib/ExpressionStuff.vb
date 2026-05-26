Public Class Expression
    Private Enum Precedence
        None = 11
        Unary = 10   ' Not actually used.
        Power = 9
        Times = 8
        Div = 7
        IntDiv = 6
        Modulus = 5
        Plus = 4
    End Enum

    ' Evaluate the expression.
    Public Shared Function Evaluate(ByVal expression As String, ByVal primitives As Dictionary(Of String, Double)) As Double
        'Dim expr As String
        'Dim is_unary As Boolean
        'Dim next_unary As Boolean
        'Dim parens As Integer
        'Dim pos As Integer
        'Dim expr_len As Integer
        'Dim ch As String
        'Dim lexpr As String
        'Dim rexpr As String
        'Dim value As String
        'Dim status As Long
        'Dim best_pos As Integer
        'Dim best_prec As Integer

        ' Remove all spaces.
        Dim expr As String = Replace$(expression, " ", "")
        Dim expr_len As Integer = expr.Length
        If expr_len = 0 Then Return 0

        ' If we find + or - now, it is a unary operator.
        Dim is_unary As Boolean = True

        ' So far we have nothing.
        Dim best_prec As Precedence = Precedence.None
        Dim best_pos As Integer = 0

        ' Find the operator with the lowest precedence.
        ' Look for places where there are no open
        ' parentheses.
        Dim parens As Integer = 0
        Dim next_unary As Boolean = False
        For pos As Integer = 0 To expr_len - 1
            ' Examine the next character.
            Dim ch As String = expr.Substring(pos, 1)

            ' Assume we will not find an operator. In
            ' that case, the next operator will not
            ' be unary.
            next_unary = False

            If ch = " " Then
                ' Just skip spaces. We keep them here
                ' to make the error messages easier to read.
            ElseIf ch = "(" Then
                ' Increase the open parentheses count.
                parens = parens + 1

                ' A + or - after "(" is unary.
                next_unary = True
            ElseIf ch = ")" Then
                ' Decrease the open parentheses count.
                parens = parens - 1

                ' An operator after ")" is not unary.
                next_unary = False

                ' If parens < 0, too many ')'s.
                If parens < 0 Then
                    Throw New NotSupportedException("Too many )s in expression '" & expression & "'")
                End If
            ElseIf parens = 0 Then
                ' See if this is an operator.
                If ch = "^" Or ch = "*" Or _
                   ch = "/" Or ch = "\" Or _
                   ch = "%" Or ch = "+" Or _
                   ch = "-" _
                Then
                    ' An operator after an operator
                    ' is unary.
                    next_unary = True

                    ' See if this operator has higher
                    ' precedence than the current one.
                    Select Case ch
                        Case "^"
                            If best_prec >= Precedence.Power Then
                                best_prec = Precedence.Power
                                best_pos = pos
                            End If

                        Case "*", "/"
                            If best_prec >= Precedence.Times Then
                                best_prec = Precedence.Times
                                best_pos = pos
                            End If

                        Case "\"
                            If best_prec >= Precedence.IntDiv Then
                                best_prec = Precedence.IntDiv
                                best_pos = pos
                            End If

                        Case "%"
                            If best_prec >= Precedence.Modulus Then
                                best_prec = Precedence.Modulus
                                best_pos = pos
                            End If

                        Case "+", "-"
                            ' Ignore unary operators
                            ' for now.
                            If (Not is_unary) And _
                                best_prec >= Precedence.Plus _
                            Then
                                best_prec = Precedence.Plus
                                best_pos = pos
                            End If
                    End Select
                End If
            End If
            is_unary = next_unary
        Next pos

        ' If the parentheses count is not zero,
        ' there's a ')' missing.
        If parens <> 0 Then
            Throw New NotSupportedException("Missing ) in expression '" & expression & "'")
        End If

        ' Hopefully we have the operator.
        If best_prec < Precedence.None Then
            Dim lexpr As String = expr.Substring(0, best_pos)
            Dim rexpr As String = expr.Substring(best_pos + 1)
            Select Case expr.Substring(best_pos, 1)
                Case "^"
                    Return _
                        Evaluate(lexpr, primitives) ^ _
                        Evaluate(rexpr, primitives)
                Case "*"
                    Return _
                        Evaluate(lexpr, primitives) * _
                        Evaluate(rexpr, primitives)
                Case "/"
                    Return _
                        Evaluate(lexpr, primitives) / _
                        Evaluate(rexpr, primitives)
                Case "\"
                    Return _
                        Evaluate(lexpr, primitives) \ _
                        Evaluate(rexpr, primitives)
                Case "%"
                    Return _
                        Evaluate(lexpr, primitives) Mod _
                        Evaluate(rexpr, primitives)
                Case "+"
                    Return _
                        Evaluate(lexpr, primitives) + _
                        Evaluate(rexpr, primitives)
                Case "-"
                    Return _
                        Evaluate(lexpr, primitives) - _
                        Evaluate(rexpr, primitives)
                Case Else ' This shouldn't happen.
                    Throw New NotSupportedException("Error evaluating expression '" & expression & "'")
            End Select
        End If

        ' If we do not yet have an operator, there
        ' are several possibilities:
        '
        ' 1. expr is (expr2) for some expr2.
        ' 2. expr is -expr2 or +expr2 for some expr2.
        ' 3. expr is Fun(expr2) for a function Fun.
        ' 4. expr is a primitive.
        ' 5. It's a literal like "3.14159".

        ' Look for (expr2).
        If expr.StartsWith("(") And expr.EndsWith(")") Then
            ' Remove the parentheses.
            Return Evaluate( _
                expr.Substring(1, expr_len - 2), _
                primitives)
        End If

        ' Look for -expr2.
        If expr.StartsWith("-") Then
            Return -Evaluate( _
                expr.Substring(1), _
                primitives)
        End If

        ' Look for +expr2.
        If expr.StartsWith("+") Then
            Return Evaluate( _
                expr.Substring(1), _
                primitives)
        End If

        ' Look for Fun(expr2).
        If expr_len > 5 And expr.EndsWith(")") Then
            ' Find the first (.
            Dim pos As Integer = expr.IndexOf("(")

            If pos > 0 Then
                ' See what the function is.
                Dim lexpr As String = expr.Substring(0, pos).ToLower()
                Dim rexpr As String = expr.Substring(pos + 1, expr_len - pos - 2)
                Select Case lexpr
                    Case "sin"
                        Return Math.Sin(Evaluate(rexpr, primitives))
                    Case "cos"
                        Return Math.Cos(Evaluate(rexpr, primitives))
                    Case "tan"
                        Return Math.Tan(Evaluate(rexpr, primitives))
                    Case "sqrt"
                        Return Math.Sqrt(Evaluate(rexpr, primitives))
                    Case "factorial"
                        Return Factorial(Evaluate(rexpr, primitives))
                    Case "log10"
                        Return Math.Log10(Evaluate(rexpr, _
                            primitives))
                        ' Add other functions (including
                        ' program-defined functions) here.
                End Select
            End If
        End If

        ' See if it's a primitive.
        If primitives.ContainsKey(expr) Then
            ' We found the primative.
            Return CDbl(primitives(expr))
        End If

        ' It must be a literal like "2.71828".
        ' Try to return it and let any errors throw.
        Return CDbl(expr)
    End Function

    ' Return the factorial of the expression.
    Private Shared Function Factorial(ByVal value As Integer) As Double
        Dim result As Double = 1
        Do While value > 1
            result *= value
            value -= 1
        Loop
        Return result
    End Function

End Class
