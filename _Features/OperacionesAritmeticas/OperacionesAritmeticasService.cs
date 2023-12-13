namespace AcademiaFS.CSharp.Tuesday._Features.OperacionesAritmeticas
{
    public class OperacionesAritmeticasService
    {
        public OperacionesAritmeticasService()
        {

        }

        public string Sumar(int primerNumero, int segundoNumero)
        {
            long resultadoSuma = primerNumero + segundoNumero;

            return $"La suma de: {primerNumero} + {segundoNumero} = {resultadoSuma}";
        }

        public string Restar(int primerNumero, int segundoNumero)
        {
            long resultadoResta = primerNumero - segundoNumero;

            return $"La resta de: {primerNumero} - {segundoNumero} = {resultadoResta}";
        }

        public string Multiplicar(int primerNumero, int segundoNumero)
        {
            long resultadoMultiplicar = primerNumero * segundoNumero;

            return $"La multiplicacion de: {primerNumero} * {segundoNumero} = {resultadoMultiplicar}";
        }

        public string Dividir(int primerNumero, int segundoNumero)
        {
            if (segundoNumero == 0)
            {
                throw new DivideByZeroException("No se puede dividir entre 0");
            }

            double resultadoDividir = (double)primerNumero / segundoNumero;
            return $"La division de: {primerNumero} / {segundoNumero} = {resultadoDividir}";
        }

    }
}
