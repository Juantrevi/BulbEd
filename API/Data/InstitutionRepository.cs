using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using BulbEd.DTOs;
using BulbEd.Entities;
using BulbEd.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BulbEd.Data;

public class InstitutionRepository : IInstitutionRepository
{
    
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public InstitutionRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public async Task<Institution> GetInstitutionById(int id)
    {
        return await _context.Institutions.FindAsync(id);
    }

    public async Task<IEnumerable<Institution>> GetInstitutions()
    {
        return await _context.Institutions.ToListAsync();
    }

    public async Task Create(InstitutionDto institutionDto)
    {
        var institution = _mapper.Map<Institution>(institutionDto);
        institution.Created = DateTime.UtcNow;
        _context.Institutions.Add(institution);
        await _context.SaveChangesAsync();
    }
    
    public async void Update(int id, InstitutionDto institutionDto)
    {
        var institution = _mapper.Map<Institution>(institutionDto);
        _context.Entry(institution).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async void Delete(int id)
    {
        var institution = _context.Institutions.Find(id);
        _context.Institutions.Remove(institution);
        await _context.SaveChangesAsync();
    }
}