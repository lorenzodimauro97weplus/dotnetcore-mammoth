namespace Mammoth.Couscous.java.lang {
    internal interface Iterable<out T> {
        util.Iterator<T> iterator();
    }
}
